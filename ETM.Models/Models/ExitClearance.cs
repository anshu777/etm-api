using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Repository.Models
{
    [Table("ExitClearance", Schema = "dbo")]
    public class ExitClearance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", Order = 1), Key]
        public int Id { get; set; }

        [Column("employee_id"),Required]
        public int EmployeeId { get; set; }

        [Column("relieving_date"), Required]
        public DateTime RelievingDate { get; set; }

        [Column("alternate_contact"), Required]
        public string AlternateContact { get; set; }

        [Column("alternate_email"), Required]
        public string AlternateEmail { get; set; }

        [Column("correspondence_address"), Required]
        public string CorrespondenceAddress { get; set; }

        [Column("knowledge_transferTo"), Required]
        public string KnowledgeTransferTo { get; set; }

        [Column("redirect_mail_to"), Required]
        public string RedirectMailTo { get; set; }

        [Column("project_clear"), Required]
        public int ProjClear  { get; set; }

        [Column("password_file_report"), Required]
        public int PswrdFileReport { get; set; }

        [Column("obervations")]
        public string Obervations { get; set; }

        [Column("reporting_manager"), Required]
        public string ReportingMngr { get; set; }

        [Column("email_deleted"), Required]
        public int EmailDeleted { get; set; }


        [Column("is_backup_taken"), Required]
        public int isBackupTaken { get; set; }

        [Column("mail_redirected_to"), Required]
        public string MailRedirectedTo { get; set; }

        [Column("laptop_recieved"), Required]
        public int LaptopRecieved { get; set; }

        [Column("mouse_recieved"), Required]
        public int MouseRecieved { get; set; }

        [Column("charger_recieved"), Required]
        public int ChargerRecieved { get; set; }

        [Column("headphone_recieved"), Required]
        public int HeadphoneRecieved { get; set; }


        [Column("is_pc_checked"), Required]
        public int isPcChecked { get; set; }

        [Column("is_observations")]
        public string IsObservations { get; set; }

        //HR DEPARTMENT

        [Column("is_book_issued"), Required]
        public int isBookIssued { get; set; }

        [Column("is_stationary_recieved"), Required]
        public int isStationaryRecieved { get; set; }

        [Column("is_cupboard_keys_recieved"), Required]
        public int isCupboardKeysRecieved { get; set; }

        [Column("is_id_card_recieved"), Required]
        public int isIdCardRecieved { get; set; }

        [Column("is_buisness_card_recieved"), Required]
        public int isBuisnessCardRecieved { get; set; }

        [Column("any_company_item"), Required]
        public string anyCompanyItem { get; set; }

        [Column("notice_period_to_be_served"), Required]
        public int NoticePeriodToBeServed { get; set; }

        [Column("np_served"), Required]
        public int NoticePeriodServed { get; set; }

        [Column("shortfall_in_notice_period")]
        public int ShortfallInNP { get; set; }

        [Column("shortfall_adjusted")]
        public int ShortfallAdjusted { get; set; }

        [Column("shortfall_waived_off")]
        public int ShortfallWaivedOff { get; set; }


        [Column("waiver_approving_auth_in_notice_period_shortfall")]
        public string WaiverApprovingAut_inNpShortfall { get; set; }

        [Column("hr_professional_name"), Required]
        public string HrProfessionalName { get; set; }

    }
}
