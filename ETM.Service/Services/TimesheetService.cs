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
            DateTime fromDate = esheet.TimesheetRows.First().timesheetColumns.Select(x => x.date).Min();
            DateTime toDate = esheet.TimesheetRows.First().timesheetColumns.Select(x => x.date).Max();

            var tsheet = await (_context.TimeSheet.Where(t => t.EmployeeId == esheet.EmployeeId && t.Date >= fromDate && t.Date <= toDate)
                                    .ToListAsync());
            if (tsheet.Count > 0)
            {
                //Update the values

                foreach (Timesheet sheet in tsheet)
                {
                    if (esheet.TimesheetRows.Where(x => x.taskId == sheet.TaskId).FirstOrDefault() != null)
                    {
                        if (esheet.TimesheetRows.Where(x => x.taskId == sheet.TaskId).FirstOrDefault()
                                    .timesheetColumns.Where(y => y.taskId == sheet.TaskId && y.date == sheet.Date).FirstOrDefault() != null)
                        {
                            sheet.Hour = esheet.TimesheetRows.Where(x => x.taskId == sheet.TaskId).FirstOrDefault()
                                    .timesheetColumns.Where(y => y.taskId == sheet.TaskId && y.date == sheet.Date).FirstOrDefault().hours;
                        }

                    }
                }
                int z = await (_context.SaveChangesAsync());
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
            EmployeeTimesheet empSheet = null;
            TimesheetRow sheetRow = null;
            var teamId = 0;
            DateTime fromDate = userDate.Date.AddDays(-1);
            DateTime toDate = userDate.Date.AddDays(6);
            using (var context = new DatabaseContext())
            {
                teamId = context.Employee.Where(x => x.BSIPLid == userDate.UserId).Select(x => x.TeamId).FirstOrDefault<int>();
                var taskTeams = await context.TaskTeam.Where(x => x.TeamId == teamId).Include(x => x.Task).ToListAsync<TaskTeam>();

                var taskGroup = (from t in taskTeams
                                 select new EmployeeTask { Id = t.TaskId, Name = t.Task.Name }).ToList();

                var tsheet1 = await (context.TimeSheet.Include(x => x.Task).Where(t => t.EmployeeId == userDate.UserId && t.Date >= fromDate && t.Date <= toDate)
                                    .ToListAsync());
                decimal workHours = 0;
                empSheet = new EmployeeTimesheet()
                {
                    EmployeeId = userDate.UserId,
                    TeamId = teamId,
                    TimesheetRows = new List<TimesheetRow>()
                };

                //select max data rom tsheets
                DateTime maxdate = new DateTime();
                if (tsheet1.Count > 0 )
                    maxdate = tsheet1[0].Date;

                foreach(Timesheet t in tsheet1)
                {
                    if (t.Date > maxdate) maxdate = t.Date;
                }

                //Prepare Colmns and Rows
                //Group by TaskIds
                //Loop through Tasks
                int ctr = 1;
                string taskName = string.Empty;
                foreach (var task in taskGroup)
                {
                    List<TimesheetColumn> cols = null;
                    //Loop through days
                    //get the actual days with dates
                    cols = new List<TimesheetColumn>();
                    var newDate = new DateTime(userDate.Date.Year, userDate.Date.Month, userDate.Date.Day, 0, 0, 0, DateTimeKind.Utc);
                    while (newDate.Date <= toDate.Date && newDate.Date <= maxdate.Date)
                    {
                        if (newDate.Date >= fromDate.Date)
                        {
                            workHours = (tsheet1 == null || tsheet1.Count == 0) ? 0 : tsheet1.Where(x => DateTime.Compare(x.Date.Date, newDate.Date) == 0 && x.TaskId == task.Id).FirstOrDefault().Hour;
                            var timesheetCol = new TimesheetColumn()
                            {
                                id = 1,
                                taskId = task.Id,
                                employeeId = userDate.UserId, //get task name
                                date = newDate,
                                hours = workHours
                                //approved = 
                            };
                            cols.Add(timesheetCol);
                            newDate = newDate.AddDays(1);
                        }
                    }

                    taskName = (tsheet1 == null || tsheet1.Count == 0) ? task.Name : tsheet1.Where(x => x.TaskId == task.Id).FirstOrDefault().Task.Name;
                    sheetRow = new TimesheetRow()
                    {
                        id = ctr,
                        taskId = task.Id,
                        taskName = taskName,
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

        public async Task<UserDateDto> Approve(UserDateDto userDate)
        {
            DateTime fromDate = userDate.Date.AddDays(-1);
            DateTime toDate = userDate.Date.AddDays(6);
            using (var context = new DatabaseContext())
            {
                var tsheet = await (from e in context.Employee
                                    join t in context.TimeSheet
                                    on e.Id equals t.EmployeeId
                                    where e.TeamId == userDate.TeamId
                                    && t.Date >= fromDate && t.Date <= toDate
                                    select t).ToListAsync();

                foreach (Timesheet sheet in tsheet)
                {
                    sheet.Approved = true;
                    sheet.ApprovedBy = userDate.UserId;
                    sheet.ApprovedDate = userDate.Date;
                }
                int z = await (context.SaveChangesAsync());
            }
            return userDate;
        }

        public async Task<UserDateDto> Unlock(UserDateDto userDate)
        {
            DateTime fromDate = userDate.Date.AddDays(-1);
            DateTime toDate = userDate.Date.AddDays(6);
            using (var context = new DatabaseContext())
            {
                var tsheet = await (from t in context.TimeSheet
                                    where t.EmployeeId == userDate.EmployeeId
                                    && t.Date >= fromDate && t.Date <= toDate
                                    select t).ToListAsync();

                foreach (Timesheet sheet in tsheet)
                {
                    sheet.Approved = false;
                    sheet.ApprovedBy = userDate.UserId;
                    sheet.ApprovedDate = userDate.Date;
                }
                int z = await (context.SaveChangesAsync());
            }
            return userDate;
        }


        public async Task<TimesheetRequestDTO> AddRequest(TimesheetRequestDTO request)
        {
            try
            {
                var req = new TimesheetRequest()
                {
                    EmpId = request.Empid,
                    Reason = request.Reason,
                    Status = request.Status,
                    ManagerId = request.ManagerId
                };
                int requestid;
                using (var _context = new DatabaseContext())
                {
                    _context.TimesheetRequest.Add(req);
                    requestid = await _context.SaveChangesAsync();

                }
                request.Id = requestid;
                return request;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<TimesheetRequestDTO> UpdateRequest(TimesheetRequestDTO request)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    TimesheetRequest tr = await _context.TimesheetRequest.Where(x => x.RequestId == request.Id).FirstOrDefaultAsync<TimesheetRequest>();
                    {
                        tr.Status = request.Status;

                        _context.SaveChanges();
                    }
                    return request;
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<TimesheetRequestDTO>> GetRequests()
        {
            List<TimesheetRequestDTO> requests = new List<TimesheetRequestDTO>();

            using (var _context = new DatabaseContext())
            {
                var reqs = await _context.TimesheetRequest.ToListAsync<TimesheetRequest>();
                foreach (TimesheetRequest t in reqs)
                {
                    TimesheetRequestDTO tmp = new TimesheetRequestDTO();
                    tmp.Id = t.RequestId;
                    tmp.Empid = t.EmpId;
                    tmp.Reason = t.Reason;
                    tmp.Status = t.Status;
                    tmp.ManagerId = t.ManagerId;
                    if (t.Status == 1) { tmp.Statusvalue = "Pending"; }
                    else if (t.Status == 2) { tmp.Statusvalue = "Approved"; }
                    else if (t.Status == 3) { tmp.Statusvalue = "Rejected"; }

                    requests.Add(tmp);
                }
            }
            return requests;
        }

        public async Task<List<TimesheetRequestDTO>> GetPendingRequests()
        {
            List<TimesheetRequestDTO> requests = null;

            using (var _context = new DatabaseContext())
            {
                var reqs = await _context.TimesheetRequest.Where(x => x.Status == 2).ToListAsync<TimesheetRequest>();
                requests = (from r in reqs
                            select new TimesheetRequestDTO()
                            {
                                Id = r.RequestId,
                                Empid = r.EmpId,
                                Reason = r.Reason,
                                Status = r.Status

                            }).ToList();
            }
            return requests;
        }


    }
}
