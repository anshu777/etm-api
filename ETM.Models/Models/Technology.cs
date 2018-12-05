using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
	[Table("technology", Schema = "dbo")]
	public class Technology
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", Order = 1), Key]
		public int Id { get; set; }

		[Column("name"), Required]
		public string Name { get; set; }
	}
}
