using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
	[Table("user_roles", Schema = "dbo")]
	public class UserRoles
	{
		[Column("user_id", Order = 1), Key]
		public int UserId { get; set; }
		[Column("role_id", Order = 2), Key]
		public int RoleId { get; set; }
	}
}
