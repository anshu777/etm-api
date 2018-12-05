using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class EmployeeTaskDto
	{
		public int id { get; set; }
		public string name { get; set; }
		public int taskType { get; set; }
		public string taskTypeName { get; set; }
		public string assignedTo { get; set; } // Comma separated team names
		public DateTime createdDate { get; set; }
	}
}
