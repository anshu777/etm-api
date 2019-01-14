using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETM.Repository.Models;
using ETM.Repository.Dto;

namespace ETM.Service.Interface
{
    public interface ITimesheetService
    {
        Task<EmployeeTimesheet> AddTimeSheet(EmployeeTimesheet esheet);
		//IQueryable<TimeSheetMasterView> ShowTimeSheet(string sortColumn, string sortColumnDir, string Search, int UserID);
		Task<EmployeeTimesheet> GetTimesheetByUserID(UserDateDto userDate);
        int DeleteTimesheetByID(long TimesheetID, long UserID);
        bool UpdateTimesheet();
		Task<UserDateDto> Approve(UserDateDto userDate);
		Task<UserDateDto> Unlock(UserDateDto userDate);
	}
}
