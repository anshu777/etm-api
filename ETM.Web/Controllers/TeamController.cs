﻿using ETM.Repository.Dto;
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
	public class TeamController : ApiController
    {
		private ITeamService _teamService;
		public TeamController(ITeamService teamService) {
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
		[Route("api/team/getlist")]
		public async Task<IHttpActionResult> GetList()
		{
			try
			{
				var result = await _teamService.GetTeams();
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[HttpPost]
		public async Task<IHttpActionResult> Post([FromBody]TeamDto project)
		{
			try
			{
				var result = await _teamService.AddTeam(project);
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[HttpPost]
		[Route("api/team/assigntasks")]
		public async Task<IHttpActionResult> Post([FromBody]TeamTasksDto teamTasksDto)
		{
			try
			{
				var result = await _teamService.AssignTasks(teamTasksDto);
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

        [HttpPut]
        // [Route("api/project/put")]
        public async Task<IHttpActionResult> Put([FromBody]TeamDto team)
        {
            try
            {
                var result = await _teamService.UpdateTeam(team);
                return this.JsonDataResult(result);
            }
            catch (Exception e)
            {
                //Logger.Log(LogLevel.Error, e);
                Console.WriteLine(e);
                return new InternalServerErrorResult(this);
            }
        }

    }
}
