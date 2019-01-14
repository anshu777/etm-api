using System;
using System.Collections.Generic;

namespace ETM.Repository.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int BSIPLid { get; set; }
        public string Name { get; set; }
        public int DesignationId { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfJoin { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int ProjectBillingStatus { get; set; }
        public string ProjectBillingStatusName { get; set; }
        public decimal JoiningCtc { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectComment { get; set; }
        public int ExperienceBeforeJoining { get; set; }
        public int TotalExperience { get; set; }
        public string TechnologyName { get; set; }
        public string Remarks { get; set; }
        public string Aadhar { get; set; }
        public string PAN { get; set; }
        public string BankAccAtJoining { get; set; }
        public string SalaryAcc { get; set; }
        public string UAN { get; set; }
        public string ContactNo { get; set; }
        public string AltContactNo { get; set; }
        public int ReportingMgr { get; set; }
        public DateTime ResignationDate { get; set; }
        public DateTime RelievingDate { get; set; }
        public string PermanentAddr { get; set; }
        public string CorrespondenceAddr { get; set; }
        public string Email { get; set; }
        public string AltEmail { get; set; }
        public List<int> skillsId { get; set; }

    }

	public class TechnologySummaryDto
	{
		public string Technology { get; set; }
		public int Approved { get; set; }
		public int Shadow { get; set; }
		public int Total { get; set; }
	}
}
