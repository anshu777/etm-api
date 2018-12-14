using ETM.Repository.Dto;
using ETM.Repository.Models;
using ETM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace ETM.Service.Services
{
	public class DesignationService : IDesignationService
	{
		public DesignationService() { }
		public async Task<List<Designation>> GetAllDesignation()
		{
			try
			{
				using (var _context = new DatabaseContext())
				{
					return await _context.Designation.ToListAsync();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<DesignationHeadCountReportDto>> GetSummaryByDesignation()
		{
			List<DesignationHeadCountReportDto> employeeList = null;
			List<DesignationStatusDto> designationStatusList = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					employeeList = await _context.Designation.Include(x => x.Category)
									.GroupBy(x => x.Category).Select(g => new DesignationHeadCountReportDto
									{
										Role = g.Key.Name
										//DesignationStatusDto = new List<DesignationStatusDto>()
									}).ToListAsync();


					foreach (DesignationHeadCountReportDto hdc in employeeList)
					{
						hdc.DesignationStatusDto = _context.Employee.Include(x => x.Designation)
									.Where(x => x.Designation.Category.Name == hdc.Role)
									.GroupBy(x => x.Designation)
									.Select(g => new DesignationStatusDto
									{
										EmployeeDesignation = g.Key.Name,
										Approved = g.Where(x => x.ProjectBillingStatus == 1).Count(),
										Shadow = g.Where(x => x.ProjectBillingStatus == 0).Count(),
										Total = g.Where(x => x.ProjectBillingStatus == 1).Count() + g.Where(x => x.ProjectBillingStatus == 0).Count()
									}).ToList();
					}

				}
				return employeeList;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
