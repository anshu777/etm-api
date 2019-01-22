using ETM.Repository.Dto;
using ETM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Interfaces
{
    public interface IOrgChartService
    {
        Task<OrgChartDto> getOrgChart(int id);
    }
}
