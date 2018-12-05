using ETM.Repository.Dto;
using ETM.Repository.Models;
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
	public class TaskController : ApiController
    {
		private ITaskService _teamService;
		public TaskController(ITaskService teamService)
		{
			_teamService = teamService;
		}

		[HttpGet]
		public async Task<IHttpActionResult> Get(int id)
		{
			try
			{
				var result = await _teamService.Get(id);
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[HttpGet]
		[Route("api/task/getlist")]
		public async Task<IHttpActionResult> GetList()
		{
			try
			{
				var result = await _teamService.GetTasks();
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[HttpPost]
		public async Task<IHttpActionResult> Post([FromBody]EmployeeTaskDto etask)
		{
			try
			{
				var result = await _teamService.AddTask(etask);
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
