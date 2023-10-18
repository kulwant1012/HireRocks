
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class GetJobsViewModel
    {
        public long? JobId { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }       
        [Display(Name = "Start Date")]
        public DateTime? JobStartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? JobEndDate { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public string Active { get; set; }
        public string HiringClosed { get; set; }
        [Display(Name = "Is Hiring Closed")]
        public bool IsHiringClosed { get; set; }
        public long? JobTypeId { get; set; }
        public decimal? FixedRate { get; set; }
    }
}
