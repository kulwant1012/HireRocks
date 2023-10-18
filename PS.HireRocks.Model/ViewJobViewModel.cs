using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class ViewJobViewModel
    {
        public long? JobId { get; set; }
        [Display(Name = "Title")]
        public string JobTitle { get; set; }
        [Display(Name = "Description")]
        public string JobDescription { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Hiring closed?")]
        public bool IsHiringClosed { get; set; }
        [Display(Name = "Worker type required")]
        public string WorkerType { get; set; }
        [Display(Name = "Experience required")]
        public string ExperienceLevel { get; set; }
        [Display(Name = "Job type")]
        public string JobType { get; set; }
        [Display(Name = "Category")]
        public string JobCategory { get; set; }
        [Display(Name = "Sub category")]
        public string JobSubCategory { get; set; }
        [Display(Name = "Start date")]
        public DateTime? JobStartDate { get; set; }
        [Display(Name = "End date")]
        public DateTime? JobEndDate { get; set; }
        [Display(Name = "Estimate duration")]
        public decimal? EstimatedDuration { get; set; }
        [Display(Name = "Time unit")]
        public string TimeUnit { get; set; }
        [Display(Name = "Client name")]
        public string ClientName { get; set; }
        public string ClientUserName { get; set; }
        [Display(Name = "Active?")]
        public string Active { get; set; }
        [Display(Name = "Hiring Closed?")]
        public string HiringClosed { get; set; }
        [Display(Name = "Job Attachments")]
        public long? JobTypeId { get; set; }
        public decimal? FixedRate { get; set; }
        public string ApplyButtonText { get; set; }
        public List<string> JobAttachmentsList { get; set; }
        public List<string> SkillsRequiredForJob { get; set; }
        public ClientInfoViewModel ClientInfoViewModel { get; set; }
        public string Locality_PRF { get; set; }
        public decimal? Max_PRF_Rate { get; set; }
        public decimal? Min_PRF_Rate { get; set; }
        public ViewJobViewModel()
        {
            SkillsRequiredForJob = new List<string>();
            JobAttachmentsList = new List<string>();
            ClientInfoViewModel = new ClientInfoViewModel();
        }
    }
}
