using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Dto
{
	public class UserDateDto
	{
		public int UserId { get; set; } //Approver
		public DateTime Date { get; set; }
		public int TeamId { get; set; }
		public int EmployeeId { get; set; }
	}
}
