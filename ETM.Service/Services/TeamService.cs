﻿using ETM.Repository.Dto;
using ETM.Repository.Models;
using ETM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Services
{
	public class TeamService : ITeamService
	{
		public async Task<TeamDto> AddTeam(TeamDto teamDto)
		{
			try
			{
				using (var _context = new DatabaseContext())
				{
					Team team = new Team()
					{
						Id = teamDto.id,
						Name = teamDto.name,
						ProjectId = teamDto.projectId,
						SetupDate = teamDto.setupDate
					};
					_context.Team.Add(team);
					int x = await (_context.SaveChangesAsync());
				}
				return teamDto;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Team> Get(int TeamId)
		{
			Team team = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					team = await _context.Team.Where(x => x.Id == TeamId).FirstOrDefaultAsync<Team>();
				}
				return team;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<TeamDto>> GetTeams()
		{
			List<TeamDto> teams = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					//var query =   (from p in _context.Project
					//			join t in _context.Team on p.Id equals t.ProjectId into teamPrj
					//			from tp in teamPrj.DefaultIfEmpty()
					//			 select new TeamDto
					//			 {
					//				 id = tp.Id,
					//				 name = tp.Name,
					//				 projectId = tp.ProjectId,
					//				 projectName = tp.Project.Name,
					//				 setupDate = tp.SetupDate
					//			 }).ToList();

					var prjs = await _context.Team.Include(x => x.Project).ToListAsync<Team>();
					teams = (from p in prjs
							 select new TeamDto
							 {
								 id = p.Id,
								 name = p.Name,
								 projectId = p.ProjectId,
								 projectName = p.Project.Name,
								 setupDate = p.SetupDate
							 }).ToList();
				}
				return teams;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
