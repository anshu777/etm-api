using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETM.Repository.Models
{
	[Table("user", Schema = "dbo")]
	public class UserModel 
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string LoggedOn { get; set; }
		public string[] Roles { get; set; }
        //public int EmpId { get; set; }
		//public virtual ICollection<Roles> Roles { get; set; }
	}
}
