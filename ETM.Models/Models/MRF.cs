using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
    [Table("MRF",Schema="dbo")]
    public class MRF
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id"), Key]
        public int id { get; set; }
        [Column("project_id")]
        public int Project { get; set; }
        [Column("projectMgr_id")]
        public int ProjectMgr { get; set; }
        [Column("designation_id")]
        public int DesignationId { get; set; }
        [Column("no_of_emp")]
        public int NoOfEmployess { get; set; }
        [Column("offered_salary")]
        public int OfferedSalary { get; set; }
        [Column("position_requested_budgeted")]
        public bool PRB { get; set; }
        [Column("is_approved")]
        public bool IsApproved { get; set; }
        [Column("remarks")]
        public string Remarks { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("new_request")]
        public Boolean NewRequest { get; set; }
        [Column("years_of_experience")]
        public int YearsOfExp { get; set; }
        [Column("location")]
        public String Location { get; set; }
    }
}
