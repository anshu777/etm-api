using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class TimesheetRow
	{
		public int Id { get; set; }
		public int TaskId { get; set; }
		public string TaskName { get; set; }
		public List<TimesheetColumn> TimesheetColumns { get; set; }
		public int TotalHours { get; set; }
	}
}
