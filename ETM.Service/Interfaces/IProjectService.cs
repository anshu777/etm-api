using ETM.Repository.Dto;
using ETM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Interface
{
    public interface IProjectService
    {
		Task<List<ProjectDto>> GetProjects();
		Task<Project> Get(int projectID);
		Task<ProjectDto> AddProject(ProjectDto project);
		//bool CheckProjectCodeExists(string ProjectCode);
		//bool CheckProjectNameExists(string ProjectName);
		//int SaveProject(ProjectMaster ProjectMaster);
		//IQueryable<ProjectMaster> ShowProjects(string sortColumn, string sortColumnDir, string Search);
		bool CheckProjectIDExistsInTimesheet(int projectID);
        int DeleteProject(int projectID);
        int GetTotalProjectsCounts();
		Task<ProjectDto> UpdateProject(ProjectDto project);
	}
}
