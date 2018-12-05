using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class OrgChartDto
	{
		public string Name { get; set; }
		public string Designation { get; set; }
        public List<OrgChartDto> Subordinates { get; set; }
	}
}
