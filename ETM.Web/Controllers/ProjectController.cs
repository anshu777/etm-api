using ETM.Repository.Dto;
using ETM.Repository.Models;
using ETM.Service.Interface;
using ETM.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ETM.Web.Controllers
{
	
	public class ProjectController : ApiController
    {
		private IProjectService _projectService;
		public ProjectController(IProjectService projectService)
		{
			_projectService = projectService;
		}

		[HttpGet]
		public async Task<IHttpActionResult> Get(int id)
		{
			try
			{
				var result = await _projectService.Get(id);
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[HttpGet]
		[Route("api/project/getlist")]
		public async Task<IHttpActionResult> GetList()
		{
			try
			{
				var result = await _projectService.GetProjects();
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[HttpPost]
		public async Task<IHttpActionResult> Post([FromBody]ProjectDto project)
		{
			try
			{
				var result = await _projectService.AddProject(project);
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
