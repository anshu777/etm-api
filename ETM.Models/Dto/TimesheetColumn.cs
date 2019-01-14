using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class TimesheetColumn
	{
		public int id { get; set; }
		public int employeeId { get; set; }
		public int taskId { get; set; }
		public DateTime date { get; set; }
		public string dayName { get; set; }
		public Decimal hours { get; set; }
		public bool approved { get; set; }
		public int approvedBy { get; set; }
		public DateTime approvedDate { get; set; }
	}
}
