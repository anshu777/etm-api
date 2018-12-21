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
		private ITaskService _taskService;
		public TaskController(ITaskService taskService)
		{
			_taskService = taskService;
		}

		[HttpGet]
		public async Task<IHttpActionResult> Get(int id)
		{
			try
			{
				var result = await _taskService.Get(id);
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
				var result = await _taskService.GetTasks();
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
				var result = await _taskService.AddTask(etask);
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[HttpDelete]
		[Route("api/task/delete/{id}")]
		public async Task<IHttpActionResult> Delete(int id)
		{
			try
			{
				await _taskService.Delete(id);
				return this.JsonDataResult("0");
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[HttpGet]
		[Route("api/task/getbyteamid/{id}")]
		public async Task<IHttpActionResult> GetByTeamId(int id)
		{
			try
			{
				var result = await _taskService.GetByTeamId(id);
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
