using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
	public class EmployeeAppraisal
	{
		[Column("employee_id"), Required]
		public int EmployeeId { get; set; }
		[Column("employee_name")]
		public string EmployeeName { get; set; }
		[Column("previous_designation")]
		public string PreviousDesignation { get; set; }
		[Column("new_designation")]
		public string NewDesignation { get; set; }
		[Column("previous_ctc")]
		public decimal PreviousCTC { get; set; }
		[Column("new_ctc")]
		public decimal NewCTC { get; set; }
		[Column("date")]
		public DateTime Date { get; set; }
		[Column("comments")]
		public string Comments { get; set; }
	}
}
