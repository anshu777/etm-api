using Autofac;
using Autofac.Integration.WebApi;
using ETM.Service;
using ETM.Service.Interface;
using ETM.Service.Interfaces;
using ETM.Service.Services;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(ETM.Web.Startup))]
namespace ETM.Web
{
	public static class Startup
	{
		public static void Configuration(IAppBuilder app)
		{
			// Get your HttpConfiguration.
			var config = new HttpConfiguration();
			var builder = new ContainerBuilder();

			var corsOrigins = ConfigurationManager.AppSettings["CORSAllowedOrigins"];
			if (!string.IsNullOrEmpty(corsOrigins))
			{
				var cors = new EnableCorsAttribute(corsOrigins, " * ", "*");
				//var cors = new EnableCorsAttribute(corsOrigins, "accept,accesstoken,authorization,cache-control,pragma,content-type,origin", "GET,PUT,POST,DELETE,TRACE,HEAD,OPTIONS");

				config.EnableCors(cors);
			}

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			//config.Filters.Add(new AuthorizeAttribute());
			
			OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
			{
				TokenEndpointPath = new PathString("/token"),
				Provider = new ApplicationOAuthProvider(),
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
				AllowInsecureHttp = true
				//,AuthorizeEndpointPath =	new PathString("/api/Account/ExternalLogin"),
			};
			app.UseOAuthAuthorizationServer(option);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

			//builder.RegisterType<Mapper>()
			//	.As<IMapper>();

			//Get assemblies to register all Repositories and Services
			var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
			var currentAssembly = Assembly.GetExecutingAssembly();

			//These can eventually be wild cards to pull in all assemblies for Repos Services and Web
			var assemblyList = assemblies as IList<Assembly> ?? assemblies.ToList();
			var etmRepoAssembly = assemblyList.Where(x => x.FullName.Contains("ETM.Repository,")).ToArray();
			var etmServiceAssembly = assemblyList.Where(x => x.FullName.Contains("ETM.Service,")).ToArray();
			var etmServiceInterfaceAssembly = etmServiceAssembly[0].DefinedTypes.Where(x => x.Name.StartsWith("I")).ToArray();

			if (etmRepoAssembly.Length > 0)
			{
				builder.RegisterAssemblyModules(etmRepoAssembly);
			}
			if (etmServiceAssembly.Length > 0)
			{
				builder.RegisterAssemblyModules(etmServiceAssembly);
			}
			//if (etmServiceInterfaceAssembly.Length > 0)
			//{
			//	builder.RegisterAssemblyModules(etmServiceInterfaceAssembly);
			//}

			builder.RegisterAssemblyModules(currentAssembly);

			//builder.Register(c => new MapperConfiguration(cfg =>
			//{
			//	//add profiles
			//	foreach (var profile in c.Resolve<IEnumerable<Profile>>())
			//	{
			//		cfg.AddProfile(profile);
			//	}
			//})).AsSelf().SingleInstance();

			////register mapper
			//builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

			// Register your Web API controllers.
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			builder.RegisterType<TimesheetService>()
				   .As<ITimesheetService>()
				   .InstancePerRequest();
			builder.RegisterType<ProjectService>()
				   .As<IProjectService>()
				   .InstancePerRequest();
			builder.RegisterType<ClientService>()
				   .As<IClientService>()
				   .InstancePerRequest();
			builder.RegisterType<TeamService>()
				   .As<ITeamService>()
				   .InstancePerRequest();
			builder.RegisterType<TaskService>()
				   .As<ITaskService>()
				   .InstancePerRequest();
			builder.RegisterType<EmployeeService>()
				   .As<IEmployeeService>()
				   .InstancePerRequest();
			builder.RegisterType<CategoryService>()
				   .As<ICategoryService>()
				   .InstancePerRequest();
			builder.RegisterType<DesignationService>()
				   .As<IDesignationService>()
				   .InstancePerRequest();
			builder.RegisterType<SkillSetService>()
				   .As<ISkillSetService>()
				   .InstancePerRequest();
			builder.RegisterType<DashboardService>()
				   .As<IDashboardService>()
				   .InstancePerRequest();
			builder.RegisterType<StatusService>()
				   .As<IStatusService>()
				   .InstancePerRequest();
 			builder.RegisterType<MRFService>()
                    .As<IMRFService>()
                    .InstancePerRequest();
            builder.RegisterType<OrgChartService>()
                    .As<IOrgChartService>()
                    .InstancePerRequest();

			ConfigureJsonSerialization(config);

			var container = builder.Build();
			app.UseAutofacMiddleware(container);
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

			app.UseAutofacWebApi(config);
			app.UseWebApi(config);

			//app.CreatePerOwinContext<UserManager<IdentityUser>>(CreateManager);

		}

		private static void ConfigureJsonSerialization(HttpConfiguration config)
		{
			var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
			config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

			var settings = config.Formatters.JsonFormatter.SerializerSettings;
			//settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			settings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
			//settings.Converters.Add(new Common.JsonConverters.TrimmingConverter());

			//To produce JSON format 
			//config.Formatters.JsonFormatter.SupportedMediaTypes
			//	.Add(new MediaTypeHeaderValue("text/html"));
		}

		//private static UserManager<IdentityUser> CreateManager(IdentityFactoryOptions<UserManager<IdentityUser>> options, IOwinContext context)
		//{
		//	var userStore = new UserStore<IdentityUser>(context.Get<OwinAuthDbContext>());
		//	var owinManager = new UserManager<IdentityUser>(userStore);
		//	return owinManager;
		//}
	}
}