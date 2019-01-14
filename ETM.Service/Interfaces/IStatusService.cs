using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETM.Repository.Dto;
using ETM.Repository.Models;

namespace ETM.Service.Interfaces
{
   public interface IStatusService
    {
        Task<List<StatusDto>> GetByStatusId(int id);
        Task<List<StatusDto>> GetAll();
        Task <Status> AddStatus(Status status);
        Task<List<StatusType>> GetAllTypes();
    }
}
