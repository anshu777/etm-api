using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETM.Repository.Models
{
	[Table("team", Schema = "dbo")]
	public class Team
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", Order = 1), Key]
		public int Id { get; set; }

		[Column("name"), Required]
		public string Name { get; set; }

		[Column("setup_date")]
		public DateTime SetupDate { get; set; }

		[Column("project_id"), Required]
		public int ProjectId { get; set; }

		public virtual Project Project { get; set; }
	}

	//public class TeamConfiguration : EntityTypeConfiguration<Team>
	//{
	//	public TeamConfiguration()
	//		: this(Constants.Schema)
	//	{
	//	}

	//	public TeamConfiguration(string schema)
	//	{
	//		ToTable("Team", schema);
	//	}
	//}
}
