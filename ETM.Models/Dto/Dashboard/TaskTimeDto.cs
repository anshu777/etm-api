using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class TaskTimeDto
	{
		public string TaskName { get; set; }
		public decimal Hours { get; set; }
		public string HoursPercentage { get; set; }
	}
}
