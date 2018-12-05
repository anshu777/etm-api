using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace ETM.Web.Common
{
	public static class ApiControllerExtensions
	{
		public static JsonResult<DataActionResult<T>> JsonDataResult<T>(this ApiController controller, T data, int totalRowCount = 0) where T : class
		{
			var settings = controller.ControllerContext.Configuration.Formatters.JsonFormatter.SerializerSettings;

			var dataResult = new DataActionResult<T>()
			{
				Data = data,
				TotalRowCount = totalRowCount
			};

			var result = new JsonResult<DataActionResult<T>>(dataResult, settings, Encoding.UTF8, controller.Request);
			return result;
		}
	}
}