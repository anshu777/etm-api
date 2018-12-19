using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class DesignationHeadCountReportDto
	{
		public string Role { get; set; }
		public List<DesignationStatusDto> DesignationStatusDto { get; set; }
	}

	public class DesignationStatusDto
	{
		public string EmployeeDesignation { get; set; }
		public int Approved { get; set; }
		public int Shadow { get; set; }
		public int Total { get; set; }
	}
}
