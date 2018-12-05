using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETM.Repository.Models
{
    [Table("designation", Schema = "dbo")]
    public class Designation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 1), Key]
        public int Id { get; set; }

        [Column("name"), Required]
        public string Name { get; set; }

		[Column("category_id")]
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }

	}
}
