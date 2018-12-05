using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETM.Repository.Models
{
    [Table("category", Schema = "dbo")]
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 1), Key]
        public int Id { get; set; }

        [Column("name"), Required]
        public string Name { get; set; }
    }
}
