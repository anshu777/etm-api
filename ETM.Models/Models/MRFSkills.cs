using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
    [Table("mrf_skills",Schema="dbo")]
    public class MRFSkills
    {
        [Column("id"),Key]
        public int id { get; set; }

        [Column("mrf_id")]
        public int MRFid { get; set; }

        [Column("skill_id")]
        public int skillid { get; set; }
    }
}
