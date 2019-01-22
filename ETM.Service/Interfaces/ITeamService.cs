using ETM.Repository.Dto;
using ETM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Interfaces
{
	public interface ITeamService
	{
		Task<List<TeamDto>> GetTeams();
		Task<Team> Get(int TeamId);
		Task<TeamDto> AddTeam(TeamDto Team);
        Task<TeamDto> UpdateTeam(TeamDto Team);
        Task<TeamTasksDto> AssignTasks(TeamTasksDto teamTasks);
	}
}
