using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETM.Repository.Models
{
    [Table("project", Schema = "dbo")]
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("project_id", Order = 1), Key]
        public int Id { get; set; }

        [Column("name"), Required]
        public string Name { get; set; }

        [Column("project_manager_id"), Required]
        public int ProjectManagerId { get; set; }

        [ForeignKey("ProjectManagerId")]
        public virtual Employee Employee { get; set; }

        [Column("client_id"), Required]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [Column("start_date"), Required]
        public DateTime StartDate { get; set; }

        [Column("end_date"), Required]
        public DateTime EndDate { get; set; }

		public virtual List<Team> Teams { get; set; }
    }
}
