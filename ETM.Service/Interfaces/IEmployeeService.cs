using ETM.Repository.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETM.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> AddEmployee(EmployeeDto employee);
        Task<List<EmployeeDto>> GetAllEmployee();
		Task<List<EmployeeDto>> GetOptionList();
		Task<List<EmployeeDto>> GetAllByReportingStructure();
		Task<List<EmployeeDto>> GetAllByRiskStatus();
		Task<List<EmployeeDto>> GetAllBySalary();
		Task<List<EmployeeDto>> GetAllByClients();

	}
}