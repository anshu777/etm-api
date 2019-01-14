using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class TeamDto
	{
		public int id { get; set; }
		public string name { get; set; }
		public DateTime setupDate { get; set; }
		public int projectId { get; set; }
		public string projectName { get; set; }
	}

}
