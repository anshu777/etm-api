using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETM.Service.Interface;
using System.Data.SqlClient;
using System.Data.Entity;
using ETM.Repository.Models;
using ETM.Repository.Dto;

namespace ETM.Service
{
	public class ProjectService : IProjectService
	{
		public ProjectService() { }

		public async Task<ProjectDto> AddProject(ProjectDto projectDto)
		{
			try
			{
				using (var _context = new DatabaseContext())
				{
					Project project = new Project()
					{
						ClientId = projectDto.clientId,
						ProjectManagerId = projectDto.projectManagerId,
						Name = projectDto.projectName,
						StartDate = projectDto.startDate,
						Comments = projectDto.comments
					};
					_context.Project.Add(project);

					int x = await (_context.SaveChangesAsync());

					ProjectSkills projectSkills = new ProjectSkills()
					{
						ProjectId = project.Id,
						PrimarySkillIds = string.Join(",", projectDto.primarySkillIds.Select(z => z.Id)),
						SecondarySkillIds = string.Join(",", projectDto.secondarySkillIds.Select(z => z.Id))
					};

					// TODO ProjectResource resource = new ProjectResource()
					_context.ProjectSkills.Add(projectSkills);

					int y = await (_context.SaveChangesAsync());

				}
				return projectDto;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public bool CheckProjectIDExistsInTimesheet(int projectID)
		{
			throw new NotImplementedException();
		}

		public int DeleteProject(int projectID)
		{
			try
			{
				Project project = new Project();// Get(projectID);

				//using (var _context = new DatabaseContext())
				//{
					
				//	_context.Project.Remove();
				//	int x = await(_context.SaveChangesAsync());
				//}
				return projectID;
			}
			catch (Exception)
			{
				throw;
			}
		}

	
		public async Task<Project> Get(int projectID)
		{
			Project project = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					project = await _context.Project.Where(x => x.Id == projectID).FirstOrDefaultAsync<Project>();
				}
				return project;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<ProjectDto>> GetProjects()
		{
			List<ProjectDto> projects = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var prjs = await _context.Project.Include(x => x.Employee).Include(x => x.Client).ToListAsync<Project>();
					projects = (from p in prjs
								select new ProjectDto
								{
									id = p.Id,
									projectName = p.Name,
									clientId =  p.ClientId,
									clientName= p.Client.Name,
									projectManager = p.Employee.Name,
									startDate = p.StartDate,
								}).ToList();
				}
				return projects;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public int GetTotalProjectsCounts()
		{
			throw new NotImplementedException();
		}
	}
}
