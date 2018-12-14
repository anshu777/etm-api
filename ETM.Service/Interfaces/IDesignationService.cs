using ETM.Repository.Dto;
using ETM.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETM.Service.Interfaces
{
    public interface IDesignationService
    {
        Task<List<Designation>> GetAllDesignation();
		Task<List<DesignationHeadCountReportDto>> GetSummaryByDesignation();
	}
}
