using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class UserRatingsViewModel
    {
        public long? UserRatingId { get; set; }
        [Display(Name=("Skill"))]
        public decimal? SkillRating { get; set; }
        [Display(Name = ("Quality"))]
        public decimal? QualityRating { get; set; }
        [Display(Name = ("Availability"))]
        public decimal? AvailabilityRating { get; set; }
        [Display(Name = ("Deadline"))]
        public decimal? DeadlineRating { get; set; }
        [Display(Name = ("Communication"))]
        public decimal? CommunicationRating { get; set; }
        [Display(Name = ("Cooperation"))]
        public decimal? CooperationRating { get; set; }
        [Display(Name = ("Comment"))]
        [Required(ErrorMessage="Please enter a comment")]
        public string Comment { get; set; }
        public DateTime? Date { get; set; }
        public string UserId { get; set; }
    }
}
