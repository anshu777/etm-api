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
using ETM.Service.Services;

namespace ETM.Service
{
	public class ProjectService : IProjectService
	{
		public ProjectService() { }
        SkillSetService skillSetService = new SkillSetService();
        EmployeeService employeeService = new EmployeeService();

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
                        //projectSkills.ProjectId = project.Id;
                        projectSkills.PrimarySkillIds = string.Join(",", projectDto.primarySkillIds.Select(z => z.Id));
                        projectSkills.SecondarySkillIds = string.Join(",", projectDto.secondarySkillIds.Select(z => z.Id));
                    };

                    // TODO ProjectResource resource = new ProjectResource()
                    if (projectSkills == null)
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

	
		public async Task<ProjectDto> Get(int projectID)
		{
			ProjectDto projectDto = null;
            Project project = null;
            try
			{
				using (var _context = new DatabaseContext())
				{
					project = await _context.Project.Where(x => x.Id == projectID).FirstOrDefaultAsync<Project>();
                    projectDto = mapProjectToProjectDto(project);
                    projectDto.primarySkillIds = new List<SkillSet>();
                    projectDto.secondarySkillIds = new List<SkillSet>();
                    ProjectSkills projectSkills = new ProjectSkills();
                    projectSkills = await _context.ProjectSkills.Where(x => x.ProjectId == projectID).FirstOrDefaultAsync<ProjectSkills>();
                    String[] primary = projectSkills.PrimarySkillIds.Split(',');
                    String[] secondary = projectSkills.SecondarySkillIds.Split(',');

                    foreach(String id in primary)
                    {
                        SkillSet skill =await skillSetService.Get(Int32.Parse(id));
                        projectDto.primarySkillIds.Add(skill);
                    }
                    foreach (String id in secondary)
                    {
                        SkillSet skill = await skillSetService.Get(Int32.Parse(id));
                        projectDto.secondarySkillIds.Add(skill);
                    }

                }
				return projectDto;
			}
			catch (Exception)
			{
				throw;
			}
		}

        private ProjectDto mapProjectToProjectDto(Project p)
        {
            ProjectDto pd = new ProjectDto();
            pd.id = p.Id;
            pd.projectName = p.Name;
            pd.startDate = p.StartDate;
            pd.projectManagerId = p.ProjectManagerId;
            pd.clientId = p.ClientId;
            pd.comments = p.Comments;

            return pd;
        }


        public async Task<List<ProjectDto>> GetProjects()
		{
			List<ProjectDto> projects = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var prjs = await _context.Project.Include(x => x.Client).ToListAsync<Project>();
					projects = (from p in prjs
								select new ProjectDto
								{
									id = p.Id,
									projectName = p.Name,
									clientId =  p.ClientId,
									clientName= p.Client.Name,
                                    projectManagerId = p.ProjectManagerId,
                                    //projectManager = p.Employee.Name,
									startDate = p.StartDate,
                                    comments = p.Comments
								}).ToList();

                    EmployeeDto emp = new EmployeeDto();
                    foreach (ProjectDto p in projects)
                    {
                         emp = await employeeService.GetById(p.projectManagerId);
                        if(emp != null)
                        p.projectManager = emp.Name;
                        else p.projectManager = "No Manager";
                    }

                    ProjectSkills projectSkills = new ProjectSkills();
                    foreach (ProjectDto pd in projects)
                    {
                        pd.primarySkillIds = new List<SkillSet>();
                        pd.secondarySkillIds = new List<SkillSet>();
                        projectSkills = await _context.ProjectSkills.Where(x => x.ProjectId == pd.id).FirstOrDefaultAsync<ProjectSkills>();
                        if (projectSkills != null)
                        {
                            String[] primary = projectSkills.PrimarySkillIds.Split(',');
                            String[] secondary = projectSkills.SecondarySkillIds.Split(',');
 
                            foreach (String id in primary)
                            {
                                SkillSet skill = await skillSetService.Get(Int32.Parse(id));
                                pd.primarySkillIds.Add(skill);
                            }
                            foreach (String id in secondary)
                            {
                                SkillSet skill = await skillSetService.Get(Int32.Parse(id));
                                pd.secondarySkillIds.Add(skill);
                            }
                        }
                    }
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
