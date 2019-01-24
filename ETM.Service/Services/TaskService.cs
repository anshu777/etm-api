using ETM.Repository.Dto;
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
	public class TaskService : ITaskService
	{
		public async Task<EmployeeTaskDto> AddTask(EmployeeTaskDto taskDto)
		{
			try
			{
				using (var _context = new DatabaseContext())
				{
					EmployeeTask task = new EmployeeTask()
					{
						Id = taskDto.id,
						Name = taskDto.name,
						TaskType = taskDto.taskType,
					};
					_context.EmployeeTask.Add(task);
					int x = await (_context.SaveChangesAsync());
				}
				return taskDto;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<EmployeeTaskDto> Get(int taskId)
		{
			EmployeeTaskDto taskDto = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var task = await _context.EmployeeTask.Where(x => x.Id == taskId).FirstOrDefaultAsync<EmployeeTask>();
					taskDto = new EmployeeTaskDto
					{
						id = task.Id,
						name = task.Name,
						taskType = task.TaskType,
						taskTypeName = "get the value based on taskType",
						assignedTo = "team1, team2, team3"
					};
				}
				return taskDto;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<EmployeeTaskDto>> GetTasks()
		{
			List<EmployeeTaskDto> tasks = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var etasks = await _context.EmployeeTask.ToListAsync<EmployeeTask>();
					tasks = (from p in etasks
							 select new EmployeeTaskDto
							 {
								 id = p.Id,
								 name = p.Name,
                                 taskType = p.TaskType,
								 taskTypeName = "TBD",
								 assignedTo = "TBD",
								 createdDate = DateTime.Now
							 }).ToList();
				}
				return tasks;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<EmployeeTaskDto>> GetByTeamId(int teamId)
		{
			List<EmployeeTaskDto> taskDto = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var tasks = await _context.TaskTeam.Include(x => x.Task).Where(x => x.TeamId == teamId).ToListAsync<TaskTeam>();
					if(tasks.Count > 0)
					{
						taskDto = new List<EmployeeTaskDto>();
						foreach (TaskTeam task in tasks)
						{
							taskDto.Add(new EmployeeTaskDto
							{
								id = task.TaskId,
								name = task.Task.Name,
							});
						}
					}
				}
				return taskDto;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task Delete(int taskId)
		{
			try
			{
				using (var _context = new DatabaseContext())
				{
					EmployeeTask task = await _context.EmployeeTask.Where(x => x.Id == taskId).FirstOrDefaultAsync<EmployeeTask>();
					if (task != null)
						_context.EmployeeTask.Remove(task);
					int y = await (_context.SaveChangesAsync());
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
