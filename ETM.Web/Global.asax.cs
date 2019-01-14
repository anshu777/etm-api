using System.Linq;
using System.Web;
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

		protected void Application_BeginRequest()
		{
			if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
			{
				if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
				{
					//These headers are handling the "pre-flight" OPTIONS call sent by the browser
					HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
					HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
					HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization, Access-Control-Request-Method, Access-Control-Request-Headers, X-Custom-Header");
					HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "60");
					HttpContext.Current.Response.End();
				}
			}
		}


	}
}
