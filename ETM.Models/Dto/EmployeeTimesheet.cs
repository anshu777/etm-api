using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class EmployeeTimesheet
	{
		public int EmployeeId { get; set; }
		public int TeamId { get; set; }
		public List<TimesheetRow> TimesheetRows { get; set; }
	}
}
