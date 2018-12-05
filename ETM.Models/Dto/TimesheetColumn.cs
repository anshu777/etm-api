using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class TimesheetColumn
	{
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public int TaskId { get; set; }
		public DateTime Date { get; set; }
		public Decimal Hours { get; set; }
	}
}
