using ETM.Service.Interfaces;
using ETM.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace ETM.Web.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class DashboardController : ApiController
    {
		private IDashboardService _dashboardService;
		public DashboardController(IDashboardService dashboardService)
		{
			_dashboardService = dashboardService;
		}

		[HttpGet]
		[Route("api/dashboard/gettasktimechart/{month}/{year}/{teamid}")]
		public async Task<IHttpActionResult> GetTaskTimeChart(int month, int year, int teamId)
		{
			try
			{
				var result = await _dashboardService.GetTaskTimeChart(month, year, teamId);
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}
	}
}
