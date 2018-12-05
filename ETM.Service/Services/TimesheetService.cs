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
			int ctr = 1;
			foreach (TimesheetRow tsr in esheet.TimesheetRows)
			{
				ctr = 1;
				DateTime fromDate = new DateTime(2018, 11, 19);
				if (tsr.TaskName.ToLower() == "total")
					break;

				foreach (TimesheetColumn tc in tsr.TimesheetColumns)
				{
					
					Timesheet ts = new Timesheet()
					{
						//Id = tsr.Id,
						EmployeeId = esheet.EmployeeId,
						TaskId = ctr, // tsr.TaskId, //fix it for real
						Date = fromDate, // tc.Date,
						Hour = tc.Hours
					};
					_context.TimeSheet.Add(ts);
					int x = await (_context.SaveChangesAsync());
					ctr++;
					fromDate = fromDate.AddDays(1);
				}
			}
		}

		public int DeleteTimesheetByID(long TimesheetID, long UserID)
		{
			throw new NotImplementedException();
		}

		public async Task<EmployeeTimesheet> GetTimesheetByUserID(long UserID)
		{
			List<Timesheet> tsheet = null;
			EmployeeTimesheet empSheet = null;
			TimesheetRow sheetRow = null;
			DateTime fromDate = new DateTime(2018, 11, 19);
			DateTime toDate = new DateTime(2018, 11, 23);
			int employeeId = 2;
			using (var context = new DatabaseContext())
			{
				tsheet = await (context.TimeSheet.Where(t => t.EmployeeId == employeeId && t.Date > fromDate && t.Date < toDate).ToListAsync());
				//tsheet.ForEach(x =>
				//{
				//	var timesheetCol = new TimesheetColumn()
				//	{
				//		Id = 1,
				//		TaskId = x.TaskId,
				//		EmployeeId = x.TaskId, //get task name
				//		Date = x.Date,
				//		Hours = x.Hour
				//	};
				//	sheetRow = new TimesheetRow
				//	sheetRow.TimesheetColumns.Add(timesheetCol);
				//});

				empSheet = new EmployeeTimesheet()
				{
					EmployeeId = 1,// UserID,
					TeamId = 1
							  //loop through Tasks
				};
				empSheet.TimesheetRows = new List<TimesheetRow>();
				//Prepare Colmns and Rows
				//Loop through Tasks
				int totalTasks = 6;
				for (int i = 1; i < totalTasks; i++)
				{
					List<TimesheetColumn> cols = null;
					//Loop through days
					//get the actual days with dates
					cols = new List<TimesheetColumn>();
					for (int j = 1; j < 7; j++)
					{
						var timesheetCol = new TimesheetColumn()
						{
							Id = 1,
							TaskId = i,
							EmployeeId = 1, //get task name
							Date = DateTime.Now.Date,
							Hours = j + 1
						};
						cols.Add(timesheetCol);
					}
					sheetRow = new TimesheetRow()
					{
						Id = i - 1,
						TaskId = i,
						TaskName = "Name", //find it
						TimesheetColumns = cols,
						TotalHours = 0
					};
					
					empSheet.TimesheetRows.Add(sheetRow);
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
