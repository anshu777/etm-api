using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class TeamTasksDto
	{
		public int TeamId { get; set; }
		public List<int> TaskIds { get; set; }
	}
}
