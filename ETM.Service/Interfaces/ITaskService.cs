using ETM.Repository.Dto;
using ETM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Interfaces
{
	public interface ITaskService
	{
		Task<List<EmployeeTaskDto>> GetTasks();
		Task<EmployeeTaskDto> Get(int taskId);
		Task<EmployeeTaskDto> AddTask(EmployeeTaskDto Task);
		Task Delete(int taskId);
		Task<List<EmployeeTaskDto>> GetByTeamId(int teamId);
	}
}
