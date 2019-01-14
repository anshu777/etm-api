using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
    

    [Table("status_type", Schema = "dbo")]
	public class StatusType
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 1), Key]
        public int Id { get; set; }

        [Column("status_type"), Required]
        public String Type { get; set; }

        

    }
}
