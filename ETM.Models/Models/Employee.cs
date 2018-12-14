using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETM.Repository.Models
{
    [Table("employee", Schema = "dbo")]
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("employee_id", Order = 1), Key]
        public int Id { get; set; }

        [Column("employee_name"), Required]
        public string Name { get; set; }

        [Column("designation_id"), Required]
        public int DesignationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [Column("date_of_join"), Required]
        public DateTime DateOfJoin { get; set; }

        [Column("category_id"), Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Column("joining_ctc"), Required]
        public decimal JoiningCtc { get; set; }

        [Column("status"), Required]
        public int Status { get; set; }

		[Column("project_billing_status")]
		public int ProjectBillingStatus { get; set; }

		[Column("team_id")]
		public int TeamId { get; set; }

		[ForeignKey("TeamId")]
		public virtual Team Team { get; set; }

		[Column("experience_before_joining")]
		public int ExperienceBeforeJoining { get; set; }

		[Column("technology_id"), Required]
		public int TechnologyId { get; set; }

		[ForeignKey("TechnologyId")]
		public virtual SkillSet Technology { get; set; }
		public string Remarks { get; set; }

	}
}
