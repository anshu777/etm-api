using ETM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
    public class StatusDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int statustypeId { get; set; }
        public string statustype { get; set; }
    }
}
