using System.Linq;
using System.Web.Http;

namespace ETM.Web
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		public object GlobalFilters { get; private set; }

		protected void Application_Start()
		{
			//GlobalConfiguration.Configure(WebApiConfig.Register);
			//Startup.Configuration();
			//FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

			//SqlDependency.Start(ConfigurationManager.ConnectionStrings["ETM_DBContext"].ToString());



		}

		
	}
}
