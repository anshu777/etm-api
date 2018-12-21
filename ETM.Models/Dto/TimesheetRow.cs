using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class TimesheetRow
	{
		public int id { get; set; }
		public int taskId { get; set; }
		public string taskName { get; set; }
		public List<TimesheetColumn> timesheetColumns { get; set; }
		public int totalHours { get; set; }
	}
}
