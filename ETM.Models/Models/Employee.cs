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

        [Column("BSIPL_id")]
        public int BSIPLid { get; set; }

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

		[Column("technology_id")]
		public int TechnologyId { get; set; }

		[ForeignKey("TechnologyId")]
		public virtual SkillSet Technology { get; set; }

        [Column("remarks")]
		public string Remarks { get; set; }

        [Column("aadhar_no")]
        public string Aadhar { get; set; }

        [Column("pancard")]
        public string PAN { get; set; }

        [Column("bank_acc_at_joining")]
        public string BankAccAtJoining { get; set; }

        [Column("salary_acc")]
        public string SalaryAcc { get; set; }

        [Column("pf_uan")]
        public string UAN { get; set; }

        [Column("contact_no")]
        public string ContactNo { get; set; }

        [Column("alt_contact_no")]
        public string AltContactNo { get; set; }

        [Column("reporting_mgr")]
        public int ReportingMgr { get; set; }

        [Column("resignation_date")]
        public DateTime ResignationDate { get; set; }

        [Column("relieving_date")]
        public DateTime RelievingDate { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("alt_email")]
        public string AltEmail { get; set; }

        [Column("permanent_addr")]
        public string PermanentAddr { get; set; }

        [Column("correspondence_addr")]
        public string CorrespondenceAddr { get; set; }

    }
}
