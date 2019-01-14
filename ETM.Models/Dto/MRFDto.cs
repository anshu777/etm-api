using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
    public class MRFDto
    {
        public int id { get; set; }
     
        public int Project { get; set; }
        
        public int ProjectMgr { get; set; }
      
        public int DesignationId { get; set; }
       
        public int NoOfEmployess { get; set; }
        
        public int OfferedSalary { get; set; }
      
        public bool PRB { get; set; }
      
        public bool IsApproved { get; set; }
        
        public string Remarks { get; set; }
     
        public DateTime Date { get; set; }

        public List<int> skillsId { get; set; }
    }
}
