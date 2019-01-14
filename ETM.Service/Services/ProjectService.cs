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
            using (var _context = new DatabaseContext())
            {
                using (DbContextTransaction trx = _context.Database.BeginTransaction())
                {
                    try
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

                        int x = (_context.SaveChanges());
                        Console.WriteLine("x=" + x);
                      
                       
                            ProjectSkills projectSkills = new ProjectSkills();
                            {
                                projectSkills.ProjectId = project.Id;
                                projectSkills.PrimarySkillIds = string.Join(",", projectDto.primarySkillIds.Select(z => z.Id));
                                projectSkills.SecondarySkillIds = string.Join(",", projectDto.secondarySkillIds.Select(z => z.Id));
                            };

                            // TODO ProjectResource resource = new ProjectResource()
                            _context.ProjectSkills.Add(projectSkills);

                            int y = (_context.SaveChanges());
                        
                      
                        trx.Commit();
                        return projectDto;
                    }
                    catch (Exception)
                    {
                        trx.Rollback();
                        throw;
                    }
                }
            }
		}

        public async Task<ProjectDto> UpdateProject(ProjectDto projectDto)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    Project project = await _context.Project.Where(x => x.Id == projectDto.id).FirstOrDefaultAsync<Project>();
                    {
                        project.ClientId = projectDto.clientId;
                        project.ProjectManagerId = projectDto.projectManagerId;
                        project.Name = projectDto.projectName;
                        project.StartDate = projectDto.startDate;
                        project.Comments = projectDto.comments;
                    };

                    int x1 = await (_context.SaveChangesAsync());
                    Console.WriteLine("x=" + x1);
                    ProjectSkills projectSkills = await _context.ProjectSkills.Where(x => x.ProjectId == projectDto.id).FirstOrDefaultAsync<ProjectSkills>();
                    if (projectSkills == null) projectSkills = new ProjectSkills();
                    {
                        projectSkills.ProjectId = project.Id;
                        projectSkills.PrimarySkillIds = string.Join(",", projectDto.primarySkillIds.Select(z => z.Id));
                        projectSkills.SecondarySkillIds = string.Join(",", projectDto.secondarySkillIds.Select(z => z.Id));
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
                                    projectManagerId = p.ProjectManagerId,
                                    projectManager = p.Employee.Name,
									startDate = p.StartDate,
                                    comments = p.Comments
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
