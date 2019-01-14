using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
	[Table("project_skills", Schema = "dbo")]
	public class ProjectSkills
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("project_id"), Key]
		public int ProjectId { get; set;}
		[Column("primary_skill_ids")]
		public string PrimarySkillIds { get; set; }
		[Column("seconday_skill_ids")]
		public string SecondarySkillIds { get; set; }
	}
}
