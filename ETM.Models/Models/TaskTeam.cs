using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETM.Repository.Models
{
    [Table("task_team", Schema = "dbo")]
    public class TaskTeam
    {
        [Column("task_id", Order = 1), Required, Key]
        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public virtual EmployeeTask Task { get; set; }

        [Column("team_id", Order = 2), Required, Key]
        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
    }
}
