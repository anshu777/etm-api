using ETM.Repository.Dto;
using ETM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ETM.Service.Interfaces;

namespace ETM.Service.Services
{
	public class DashboardService : IDashboardService
	{
		public async Task<List<TaskTimeDto>> GetTaskTimeChart(int month, int year, int teamId)
		{
			List<TaskTimeDto> taskVsTime = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					//get tasks for the team based on teamId
					var taskTeam = await _context.TaskTeam.Include(x => x.Task).Where(x => x.TeamId == teamId).ToListAsync<TaskTeam>();
					var employees = await _context.Employee.Include(x => x.Team).Where(x => x.TeamId == teamId).ToListAsync<Employee>();
					var taskHours = (from e in employees
									 join ts in _context.TimeSheet
									 on e.Id equals ts.EmployeeId
									 where ts.Date.Month == month && ts.Date.Year == year
									 group ts by ts.TaskId into grp
									 select new
									 {
										 taskId = grp.Key,
										 taskName = taskTeam.Find(x => x.TaskId == grp.Key).Task.Name,
										 taskTotalHours = grp.Sum(x => x.Hour)
									 });
					var totalHours = taskHours.Sum(x => x.taskTotalHours);
					taskVsTime = (from tt in taskTeam
									  join th in taskHours
									  on tt.TaskId equals th.taskId
									  select new TaskTimeDto
									  {
										  TaskName = th.taskName,
										  Hours = th.taskTotalHours,
										  HoursPercentage = (th.taskTotalHours * 100 / totalHours).ToString()
									  }).ToList();

				}
				return taskVsTime;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
