using ETM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class ProjectDto
	{
		public int id { get; set; }
		public string projectName { get; set; }
		public int clientId { get; set; }
		public int projectManagerId { get; set; }
		public string projectManager { get; set; }
		public string clientName { get; set; }
		public string comments { get; set; }
		public DateTime startDate { get; set; }
		public DateTime dueDate { get; set; }
		public List<SkillSet> primarySkillIds { get; set; }
		public List<SkillSet> secondarySkillIds { get; set; }
	}
}
