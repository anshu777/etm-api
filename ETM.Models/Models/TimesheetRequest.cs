using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
    [Table("timesheet_requests", Schema = "dbo")]
    public class TimesheetRequest
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("request_id", Order = 1), Key]
        public int RequestId { get; set; }

        
        [Column("emp_id"), Required]
        public int EmpId { get; set; }

        [Column("manager_id"), Required]
        public int ManagerId { get; set; }

        [Column("reason"), Required]
        public string Reason { get; set; }

        [Column("request_status")]
        public int Status { get; set; }




    }
}
