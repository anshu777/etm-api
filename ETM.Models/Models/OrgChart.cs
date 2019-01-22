using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
    public class OrgChart
    {
        [Column("id"),Key]
        public int id { get; set; }
        public string name { get; set; }
        public string designation { get; set; }
    }
}
