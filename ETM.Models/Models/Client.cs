using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETM.Repository.Models
{
    [Table("client", Schema = "dbo")]
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("client_id", Order = 1), Key]
        public int Id { get; set; }

        [Column("name"), Required]
        public string Name { get; set; }

		[Column("address"), Required]
		public string OfficeAddress { get; set; }
	}
}
