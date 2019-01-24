using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
    public class TimesheetRequestDTO
    {
        public int Id { get; set; }
        public int Empid { get; set; }
        public string Reason { get; set; }
        public int Status { get; set; }
        public string Statusvalue { get; set; }
        public int ManagerId { get; set; }

    }
}
