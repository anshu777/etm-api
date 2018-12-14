using System;

namespace ETM.Repository.Dto
{
	public class EmployeeDto
	{
		public int Id { get; set; }
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
		public int ExperienceBeforeJoining { get; set; }
		public int TotalExperience { get; set; }
		public string TechnologyName { get; set; }
		public string Remarks { get; set; }
	}

	public class TechnologySummaryDto
	{
		public string Technology { get; set; }
		public int Approved { get; set; }
		public int Shadow { get; set; }
		public int Total { get; set; }
	}
}
