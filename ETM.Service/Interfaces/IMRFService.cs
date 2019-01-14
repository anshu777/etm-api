using ETM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Interfaces
{
    public interface IMRFService
    {
        Task<MRFDto> AddMRFRaise(MRFDto mrfdto);
    }
}
