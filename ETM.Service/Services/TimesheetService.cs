using ETM.Repository.Models;
using ETM.Service.Interface;
using ETM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ETM.Service
{
	public class TimesheetService : ITimesheetService
	{
		public TimesheetService() { }
		public async Task<EmployeeTimesheet> AddTimeSheet(EmployeeTimesheet esheet)
		{
			try
			{
				using (var _context = new DatabaseContext())
				{
					await AddEmployeeTimesheet(esheet, _context);
				}
				return esheet;
			}
			catch (Exception)
			{
				throw;
			}
		}

		private async Task AddEmployeeTimesheet(EmployeeTimesheet esheet, DatabaseContext _context)
		{
			esheet.EmployeeId = 2;
			DateTime fromDate = esheet.TimesheetRows.First().timesheetColumns.Select(x => x.date).Min();
			DateTime toDate = esheet.TimesheetRows.First().timesheetColumns.Select(x => x.date).Max();

			var tsheet = await (_context.TimeSheet.Where(t => t.EmployeeId == esheet.EmployeeId && t.Date >= fromDate && t.Date <= toDate)
									.ToListAsync());
			if(tsheet.Count > 0)
			{
				//Update the values
				return;
			}

			int ctr = 1;
			foreach (TimesheetRow tsr in esheet.TimesheetRows)
			{
				ctr = 1;
				if (tsr.taskName.ToLower() == "total")
					break;

				foreach (TimesheetColumn tc in tsr.timesheetColumns)
				{
					Timesheet ts = new Timesheet()
					{
						//Id = tsr.Id,
						EmployeeId = esheet.EmployeeId,
						TaskId = tc.taskId,
						Date = tc.date,
						Hour = tc.hours
					};
					_context.TimeSheet.Add(ts);
					int x = await (_context.SaveChangesAsync());
					ctr++;
				}
			}
		}

		public int DeleteTimesheetByID(long TimesheetID, long UserID)
		{
			throw new NotImplementedException();
		}

		public async Task<EmployeeTimesheet> GetTimesheetByUserID(UserDateDto userDate)
		{
			List<Timesheet> tsheet = null;
			EmployeeTimesheet empSheet = null;
			TimesheetRow sheetRow = null;
			DateTime fromDate = userDate.Date.AddDays(-1);
			DateTime toDate = userDate.Date.AddDays(6);
			using (var context = new DatabaseContext())
			{
				var tsheet1 = await (context.TimeSheet.Include(x => x.Task).Where(t => t.EmployeeId == userDate.UserId && t.Date >= fromDate && t.Date <= toDate)
									.ToListAsync());

				//pull tasks for this employee by teamId
				var taskGroup = tsheet1.GroupBy(x => new { x.TaskId })
								.Select(g => g.Key)
								.ToList();

				empSheet = new EmployeeTimesheet()
				{
					EmployeeId = userDate.UserId,
					TeamId = 1
					//loop through Tasks
				};
				empSheet.TimesheetRows = new List<TimesheetRow>();
				//Prepare Colmns and Rows
				//Group by TaskIds
				//Loop through Tasks
				int ctr = 1;
				foreach (var task in taskGroup)
				{
					List<TimesheetColumn> cols = null;
					//Loop through days
					//get the actual days with dates
					cols = new List<TimesheetColumn>();
					var newDate = userDate.Date;
					while (newDate.Date <= toDate.Date)
					{
						var timesheetCol = new TimesheetColumn()
						{
							id = 1,
							taskId = task.TaskId,
							employeeId = userDate.UserId, //get task name
							date = newDate,
							hours = tsheet1.Where(x => DateTime.Compare(x.Date.Date, newDate.Date) == 0 && x.TaskId == task.TaskId).FirstOrDefault().Hour
						};
						cols.Add(timesheetCol);
						newDate = newDate.AddDays(1);
					}
					sheetRow = new TimesheetRow()
					{
						id = ctr,
						taskId = task.TaskId,
						taskName = tsheet1.Where(x => x.TaskId == task.TaskId).FirstOrDefault().Task.Name,
						timesheetColumns = cols,
						totalHours = 0
					};

					empSheet.TimesheetRows.Add(sheetRow);
					ctr++;
				}
			}

			return empSheet;
		}

		public bool UpdateTimesheet()
		{
			throw new NotImplementedException();
		}


	}
}
