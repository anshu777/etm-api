using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ETM.Repository;

namespace ETM.Repository.Models
{
    [Table("employee_task", Schema = "dbo")]

	public class EmployeeTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 1), Key]
        public int Id { get; set; }

        [Column("name"), Required]
        public string Name { get; set; }

		[Column("task_type"), Required]
		public int TaskType { get; set; }
    }
}
