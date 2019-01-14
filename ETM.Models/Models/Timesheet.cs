using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETM.Repository.Models
{
    [Table("timesheet", Schema = "dbo")]
    public class Timesheet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("timesheet_id", Order = 1), Key]
        public int Id { get; set; }

        [Column("employee_id"), Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [Column("task_id"), Required]
        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public virtual EmployeeTask Task { get; set; }

        [Column("date"), Required]
        public DateTime Date { get; set; }

        [Column("hour"), Required]
        public decimal Hour { get; set; }

		[Column("approved")]
		public bool Approved { get; set; }

		[Column("approved_by")]
		public int ApprovedBy { get; set; }

		[Column("approved_date")]
		public DateTime ApprovedDate { get; set; }
	}
}
