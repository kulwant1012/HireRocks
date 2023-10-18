using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PS.HireRocks.Model
{
    public class ContractViewModel
    {
        public long? ContractId { get; set; }
        public long? JobBidId { get; set; }

        [Required(ErrorMessage = "Please select {0}")]
        [Display(Name = "Worker")]
        [StringLength(50, ErrorMessage = "Max 50 characters allowed")]
        public string WorkerId { get; set; }

        [Required(ErrorMessage = "Please select {0}")]
        [Display(Name = "Job")]
        public long? JobId { get; set; }

        [Display(Name = "Start date")]
        public DateTime? JobStartDate { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [Display(Name = "Hourly rate")]
        public decimal? HourlyRate { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [Display(Name = "Fixed rate")]
        public decimal? FixedRate { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [Display(Name = "Estimated duration")]
        public decimal? EstimatedDuration { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [Display(Name = "Weekly hour limit")]
        [Range(1, 168, ErrorMessage = "Must enter value between {0} & {1}")]
        public decimal? WeeklyHourLimit { get; set; }

        [Required(ErrorMessage = "Please select {0}")]
        [Display(Name = "Time unit")]
        public long? TimeUnitId { get; set; }

        [Display(Name = "Contract status")]
        public long? COntractStatusId { get; set; }

        [Display(Name = "Contract end date")]
        public DateTime? ContractEndDate { get; set; }

        [Display(Name = "Contract end reason")]
        public string EndReason { get; set; }

        [Required(ErrorMessage = "Please select end reason")]
        public long? EndReasonId { get; set; }

        [Display(Name = "Other end reason")]
        [Required(ErrorMessage = "Please specify other reason")]
        public string OtherEndReason { get; set; }

        [Display(Name = "End contract?")]
        public bool IsEndingContract { get; set; }

        [Display(Name = ("Actual duration"))]
        public string ActualDuration { get; set; }

        [Display(Name = "Job title")]
        public string JobTitle { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfileTitle { get; set; }
        public string Country { get; set; }
        public string ProfileImage { get; set; }
        public decimal? Rating { get; set; }
        public decimal? JobRate { get; set; }
        public bool IsHired { get; set; }
        public bool IsDenied { get; set; }
        public string CoverLetter { get; set; }
        public long? JobTypeId { get; set; }
        [Display(Name = "Type")]
        public string JobTypeName { get; set; }
        public string TimeUnitName { get; set; }
        [Display(Name = "Client name")]
        public string ClientName { get; set; }
        public string ClientUserName { get; set; }
        public string CreatedModifiedByUserId { get; set; }
        public bool IsSubmitedSuccessfully { get; set; }
        public DateTime? HourlyRateFromOrToDate { get; set; }
        public decimal? WorkerHourlyRate { get; set; }

        public int? ExistingContractsCount { get; set; }
        public string HireButtonText { get; set; }

        public UserRatingsViewModel UserRatingsViewModel { get; set; }
        public IEnumerable<SelectListItem> JobsList { get; set; }
        public IEnumerable<SelectListItem> TimeUnitsList { get; set; }
        public IEnumerable<SelectListItem> ContractStatusList { get; set; }
        public IEnumerable<JobAttachmentsViewModel> AttachmentsList { get; set; }
        public ContractViewModel()
        {
            UserRatingsViewModel = new UserRatingsViewModel();
        }
    }
}
