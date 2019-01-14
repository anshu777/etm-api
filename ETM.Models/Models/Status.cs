using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
    [Table("status", Schema = "dbo")]
    public class Status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("status_name"), Required]
        public String Name { get; set; }

        [Column("status_type_id"), Required]
        public int StatusTypeId { get; set; }

        [ForeignKey("StatusTypeId")]
        public virtual StatusType StatusType { get; set; }

        [Column("status_description")]
        public string Description { get; set; }
    }
}
