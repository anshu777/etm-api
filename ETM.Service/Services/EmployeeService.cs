using ETM.Repository.Dto;
using ETM.Repository.Models;
using ETM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ETM.Service.Services
{
	public class EmployeeService : IEmployeeService
	{
		public async Task<EmployeeDto> AddEmployee(EmployeeDto employee)
		{
			try
			{
				var emp = mapDtoToEmployeeEntity(employee);
				int empId;
				using (var _context = new DatabaseContext())
				{
					_context.Employee.Add(emp);
					empId = await _context.SaveChangesAsync();
                    
                    foreach(int i in employee.skillsId)
                    {
                        EmployeeTechnology et = new EmployeeTechnology();
                        et.EmployeeId = emp.Id;
                        et.TechnologyId = i;
                        _context.EmployeeTechnology.Add(et);
                        _context.SaveChanges();

                    }
                    
                    
				}
                
				employee.Id = empId;
				return employee;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<EmployeeDto>> GetOptionList()
		{
			List<EmployeeDto> employeeList = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var emps = await _context.Employee.ToListAsync<Employee>();
					employeeList = (from e in emps
									select new EmployeeDto()
									{
										Id = e.Id,
										Name = e.Name,
									}).ToList();
				}
				return employeeList;
			}
			catch (Exception)
			{
				throw;
			}
		}
		public async Task<List<EmployeeDto>> GetAllEmployee()
		{
			List<EmployeeDto> employeeList = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var emps = await _context.Employee.Include(x => x.Category).Include(x => x.Designation).Include(x => x.Team).Include(x => x.Status).ToListAsync<Employee>();
					employeeList = (from e in emps
									select new EmployeeDto()
									{
										Id = e.Id,
										Name = e.Name,
                                        BSIPLid = e.BSIPLid,
                                        Designation = e.Designation.Name,
										DateOfJoin = e.DateOfJoin,
										CategoryId = e.CategoryId,
										Category = e.Category.Name,
										JoiningCtc = e.JoiningCtc,
										ProjectBillingStatusName = e.ProjectBillingStatus == 1 ? "Approved" : "Shadow",
										StatusName = e.Status.Name, 
										TeamName = e.Team.Name
									}).ToList();
				}
				return employeeList;

			}
			catch (Exception e)
			{
				throw;
			}
		}

		public async Task<EmployeeDto> GetById(int employeeId)
		{
			EmployeeDto employee = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
                    List<EmployeeTechnology> ets = null;
                    var Ets = await _context.EmployeeTechnology.Where(x => x.EmployeeId == employeeId).Include(x => x.Technology).ToListAsync<EmployeeTechnology>();

                    List<SkillSet> primary = new List<SkillSet>();
                    List<SkillSet> secondary = new List<SkillSet>();

                    //  (from e in Ets
                    //   select new
                    //   ).FirstOrDefault();

                    foreach (var e in Ets)
                    {
                        if(e.Technology.IsPrimary==1)
                        {
                            primary.Add(new SkillSet
                            {
                                Id = e.Technology.Id,
                                Name = e.Technology.Name,
                                IsPrimary = e.Technology.IsPrimary
                            });
                        }
                        else
                        {
                            secondary.Add(new SkillSet
                            {
                                Id = e.Technology.Id,
                                Name = e.Technology.Name,
                                IsPrimary = e.Technology.IsPrimary
                            });
                        }
                    }


                    var emps = await _context.Employee.Where(x => x.Id == employeeId).Include(x => x.Category).Include(x => x.Designation).Include(x => x.Team).Include(x => x.Status).ToListAsync<Employee>();
                    employee = (from e in emps
                                select new EmployeeDto()
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    BSIPLid = e.BSIPLid,
                                    DesignationId = e.DesignationId,
                                    Designation = e.Designation.Name,
                                    DateOfJoin = e.DateOfJoin,
                                    CategoryId = e.CategoryId,
                                    Category = e.Category.Name,
                                    JoiningCtc = e.JoiningCtc,
                                    ProjectBillingStatusName = e.ProjectBillingStatus == 1 ? "Approved" : "Shadow",
                                    Status = e.StatusId,
                                    StatusName = e.Status.Name,
                                    TeamId = e.TeamId,
                                    TeamName = e.Team.Name,
                                    ExperienceBeforeJoining = e.ExperienceBeforeJoining,
                                    Remarks = e.Remarks,
                                    Aadhar = e.Aadhar,
                                    PAN = e.PAN,
                                    UAN = e.UAN,
                                    BankAccAtJoining = e.BankAccAtJoining,
                                    SalaryAcc = e.SalaryAcc,
                                    ContactNo = e.ContactNo,
                                    AltContactNo = e.AltContactNo,
                                    ReportingMgr = e.ReportingMgr,
                                    ResignationDate = e.ResignationDate,
                                    RelievingDate = e.RelievingDate,
                                    PermanentAddr = e.PermanentAddr,
                                    CorrespondenceAddr = e.CorrespondenceAddr,
                                    Email = e.Email,
                                    AltEmail = e.AltEmail,
                                    Primary = primary,
                                    Secondry = secondary
                                  
								}).FirstOrDefault();
				}
				return employee;

			}
			catch (Exception e )
			{
				throw;
			}
		}



        private Employee mapDtoToEmployeeEntity(EmployeeDto employee)
		{
            //int tech[]
            return new Employee()
            {
                BSIPLid = employee.BSIPLid,
                Name = employee.Name,
                DesignationId = employee.DesignationId,
                DateOfJoin = employee.DateOfJoin,
                CategoryId = employee.CategoryId,
                JoiningCtc = employee.JoiningCtc,
               StatusId = employee.Status,
                TeamId = employee.TeamId,
                ExperienceBeforeJoining = employee.ExperienceBeforeJoining,
                Remarks = employee.Remarks,
                Aadhar = employee.Aadhar,
                PAN = employee.PAN,
                BankAccAtJoining = employee.BankAccAtJoining,
                SalaryAcc = employee.SalaryAcc,
                UAN = employee.UAN,
                ContactNo = employee.ContactNo,
                AltContactNo = employee.AltContactNo,
                Email = employee.Email,
                AltEmail = employee.AltEmail,
                PermanentAddr = employee.PermanentAddr,
                CorrespondenceAddr = employee.CorrespondenceAddr
			};
		}
		private List<EmployeeDto> mapEmployeeEntityToDto(List<Employee> employees)
		{
			var empDto = new List<EmployeeDto>();
			foreach (var e in employees)
			{
				var emp = new EmployeeDto()
				{
					Id = e.Id,
					Name = e.Name,
					Designation = e.Designation.Name,
					DateOfJoin = e.DateOfJoin,
					CategoryId = e.CategoryId,
					Category = e.Category.Name,
					JoiningCtc = e.JoiningCtc,
					ProjectBillingStatusName = e.ProjectBillingStatus == 1 ? "Approved" : "Shadow",
					StatusName = e.Status.Name 

				};
				empDto.Add(emp);
			}
			return empDto;
		}

		public async Task<List<EmployeeDto>> GetAllByReportingStructure()
		{
			List<EmployeeDto> employeeList = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var emps = await _context.Employee.Include(x => x.Category).Include(x => x.Designation).Include(x => x.Team).Include(x => x.Status).ToListAsync<Employee>();
					employeeList = (from e in emps
									select new EmployeeDto()
									{
										Id = e.Id,
										Name = e.Name,
										Designation = e.Designation.Name,
										DateOfJoin = e.DateOfJoin,
										CategoryId = e.CategoryId,
										Category = e.Category.Name,
										JoiningCtc = e.JoiningCtc,
										ProjectBillingStatusName = e.ProjectBillingStatus == 1 ? "Approved" : "Shadow",
										StatusName = e.Status.Name,
										TeamName = e.Team.Name
									}).ToList();
				}
				return employeeList;

			}
			catch (Exception)
			{
				throw;
			}

		}
		public async Task<List<EmployeeDto>> GetAllByRiskStatus()
		{
			List<EmployeeDto> employeeList = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var emps = await _context.Employee.Include(x => x.Category).Include(x => x.Designation).Include(x => x.Team).Include(x => x.Status).ToListAsync<Employee>();
					employeeList = (from e in emps
									select new EmployeeDto()
									{
										Id = e.Id,
										Name = e.Name,
										Designation = e.Designation.Name,
										DateOfJoin = e.DateOfJoin,
										CategoryId = e.CategoryId,
										Category = e.Category.Name,
										JoiningCtc = e.JoiningCtc,
										ProjectBillingStatusName = e.ProjectBillingStatus == 1 ? "Approved" : "Shadow",
										StatusName = e.Status.Name, 
										TeamName = e.Team.Name
									}).ToList();
				}
				return employeeList;

			}
			catch (Exception)
			{
				throw;
			}
		}
		public async Task<List<EmployeeDto>> GetAllBySalary()
		{
			List<EmployeeDto> employeeList = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var emps = await _context.Employee.Include(x => x.Category).Include(x => x.Designation).Include(x => x.Status).Include(x => x.Team).ToListAsync<Employee>();
					employeeList = (from e in emps
									select new EmployeeDto()
									{
										Id = e.Id,
										Name = e.Name,
										Designation = e.Designation.Name,
										DateOfJoin = e.DateOfJoin,
										CategoryId = e.CategoryId,
										Category = e.Category.Name,
										JoiningCtc = e.JoiningCtc,
										ProjectBillingStatusName = e.ProjectBillingStatus == 1 ? "Approved" : "Shadow",
										StatusName = e.Status.Name, 
										TeamName = e.Team.Name
									}).ToList();
				}
				return employeeList;

			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<EmployeeDto>> GetAllByClients()
		{
			List<EmployeeDto> employeeList = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var teams = await _context.Team.Include(x => x.Project).ToListAsync<Team>();
					var emps = await _context.Employee.Include(x => x.Category).Include(x => x.Designation).Include(x => x.Team).Include(x => x.Status).Include(x => x.Technology).ToListAsync<Employee>();
					var employeeList1 = (from t in teams
										 join e in emps
										 on t.Id equals e.TeamId
										 group e
										  by new
										  {
											  t.ProjectId,
											  t.Id,
											  e.CategoryId,
											  employee = e
										  } into grouped
										 orderby grouped.Key.ProjectId, grouped.Key.Id, grouped.Key.CategoryId
										 select new
										 {
											 grouped.Key.ProjectId,
											 grouped.Key.Id,
											 grouped.Key.CategoryId,
											 grouped.Key.employee
										 }).ToList();

					employeeList = (from e in employeeList1
									select new EmployeeDto
									{
										Id = e.employee.Id,
										Name = e.employee.Name,
										Designation = e.employee.Designation.Name,
										DateOfJoin = e.employee.DateOfJoin,
										CategoryId = e.employee.CategoryId,
										Category = e.employee.Category.Name,
										JoiningCtc = e.employee.JoiningCtc,
										ProjectBillingStatusName = e.employee.ProjectBillingStatus == 1 ? "Approved" : "Shadow",
										StatusName = e.employee.Status.Name, 
										TeamName = e.employee.Team.Name,
										ProjectName = e.employee.Team.Project.Name,
                                        ProjectComment = e.employee.Team.Project.Comments,
										TotalExperience = e.employee.ExperienceBeforeJoining + Convert.ToDateTime(e.employee.DateOfJoin).Year,
										TechnologyName = e.employee.Technology.Name,
										Remarks = e.employee.Remarks
									}).ToList();
				}
				return employeeList;

			}
			catch (Exception)
			{
				throw;
			}
		}


		public async Task<List<TechnologySummaryDto>> GetSummaryByTechnology()
		{
			List<TechnologySummaryDto> employeeList = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var emps = await _context.Employee.Include(x => x.Technology).ToListAsync<Employee>();
					employeeList = (from e in emps
									group e
									 by new
									 {
										 Technology = e.Technology.Name
										 //employee = e
									 } into grouped
									orderby grouped.Key.Technology
									let app = grouped.Where(x => x.ProjectBillingStatus == 1).Count()
									let shd = grouped.Where(x => x.ProjectBillingStatus == 0).Count()
									select new TechnologySummaryDto
									{
										Technology = grouped.Key.Technology,
										Approved = app,
										Shadow = shd,
										Total = app + shd
									}).ToList();


				}
				return employeeList;

			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<EmployeeDto>> GetDetailByTechnology()
		{
			List<EmployeeDto> employeeList = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					var teams = await _context.Team.Include(x => x.Project).ToListAsync<Team>();
					var emps = await _context.Employee.Include(x => x.Category).Include(x => x.Designation).Include(x => x.Team).Include(x => x.Technology).ToListAsync<Employee>();
					var employeeList1 = (from t in teams
										 join e in emps
										 on t.Id equals e.TeamId
										 group e
										  by new
										  {
											  t.ProjectId,
											  e.TechnologyId,
											  employee = e
										  } into grouped
										 orderby grouped.Key.ProjectId, grouped.Key.TechnologyId
										 select new
										 {
											 grouped.Key.ProjectId,
											 grouped.Key.TechnologyId,
											 grouped.Key.employee
										 }).ToList();

					employeeList = (from e in employeeList1
									select new EmployeeDto
									{
										Id = e.employee.Id,
										Name = e.employee.Name,
										Designation = e.employee.Designation.Name,
										DateOfJoin = e.employee.DateOfJoin,
										CategoryId = e.employee.CategoryId,
										Category = e.employee.Category.Name,
										JoiningCtc = e.employee.JoiningCtc,
										ProjectBillingStatusName = e.employee.ProjectBillingStatus == 1 ? "Approved" : "Shadow",
										StatusName = e.employee.Status.Name,
										TeamName = e.employee.Team.Name,
										ProjectName = e.employee.Team.Project.Name,
										TotalExperience = e.employee.ExperienceBeforeJoining + Convert.ToDateTime(e.employee.DateOfJoin).Year,
										TechnologyName = e.employee.Technology.Name,
										Remarks = e.employee.Remarks
									}).ToList();
				}
				return employeeList;

			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<OptionDto>> GetByDesignationId(int designationId)
		{
			List<OptionDto> empList = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
                    
                    var emps = await _context.Employee.Where(x => x.DesignationId == designationId).ToListAsync<Employee>();
					empList = (from e in emps
							   select new OptionDto()
							   {
								   Id = e.Id,
								   Name = e.Name
							   }).ToList();
				}
				return empList;

			}
			catch (Exception)
			{
				throw;
			}
		}


        //org chart

        public class tempdto
        {
            int id { get; set; }
            List<EmployeeDto> edto { get; set; }
        }

        public async  Task<OrgChartDto> GetChart(int projectid)
        {
            OrgChartDto oc = new OrgChartDto();
            EmployeeDto ed = null;
            tempdto td = new tempdto();
            oc.name = "UNO";
            oc.designation = "CEO";
            try
            {
                using (var _context = new DatabaseContext())
                {
                    var teams = await _context.Team.Where(x => x.ProjectId==projectid).ToListAsync<Team>();
                    oc.subordinates = (from t in teams
                                       select new OrgChartDto
                                       {
                                           name = t.Name,
                                           designation = "team"
                                       }).ToList();
                }


                    return oc;

            }
            catch(Exception e)
            {
                throw;
            }


        }
        

    }
}