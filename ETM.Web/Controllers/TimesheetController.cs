using ETM.Repository.Dto;
using ETM.Service.Interface;
using ETM.Web.Common;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace ETM.Web.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class TimesheetController : ApiController
	{
		private ITimesheetService _timesheetService;
		public TimesheetController(ITimesheetService timesheetService)
		{
			_timesheetService = timesheetService;
		}

		//public TimesheetController()
		//{

		//}

		[HttpPost]
		[Route("api/timesheet/getbyuserid")]
		public async Task<IHttpActionResult> GetByUserId([FromBody] UserDateDto userDate)
		{
			try
			{
				var result = await _timesheetService.GetTimesheetByUserID(userDate);
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[HttpPost]
		[Route("api/timesheet/save/")]
		public async Task<IHttpActionResult> PostTimesheet([FromBody]EmployeeTimesheet esheet)
		{
			try
			{
				var result = await _timesheetService.AddTimeSheet(esheet);
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[HttpPost]
		[Route("api/timesheet/approve/")]
		public async Task<IHttpActionResult> PostApprove([FromBody]UserDateDto userDate)
		{
			try
			{
				var result = await _timesheetService.Approve(userDate);
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[HttpPost]
		[Route("api/timesheet/unlock/")]
		public async Task<IHttpActionResult> PostUnlock([FromBody]UserDateDto userDate)
		{
			try
			{
				var result = await _timesheetService.Unlock(userDate);
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
