using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
    [Table("employee_technology", Schema = "dbo")]
    public class EmployeeTechnology
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id"), Key]
        public int id { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("employee_id"), Required]
        public int EmployeeId { get; set; }

        [Column("technology_id"), Required]
        public int TechnologyId { get; set; }

        [ForeignKey("TechnologyId")]
        public virtual SkillSet Technology { get; set; }
    }
}
