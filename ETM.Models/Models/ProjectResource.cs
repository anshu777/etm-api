using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
	public class ProjectResource
	{
		[Column("project_id"), Key]
		public int ProjectId { get; set; }
		[Column("category_id")]
		public int CategoryId { get; set; }
		[Column("number_of_resource")]
		public int NumberOfResources { get; set; }
		[Column("designation_id")]
		public int DesignationId { get; set; }
		[Column("isapproved")]
		public byte IsApproved { get; set; }
		[Column("isshadow")]
		public byte IsShadow { get; set; }
		
	}
}
