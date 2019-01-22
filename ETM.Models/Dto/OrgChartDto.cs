using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class OrgChartDto
	{
		public string name { get; set; }
		public string designation { get; set; }
        public List<OrgChartDto> subordinates { get; set; }
	}
}
