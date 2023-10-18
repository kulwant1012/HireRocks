using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PS.HireRocks.Model
{
    public class FindWorkerViewModel
    {
        public FindWorkerFilter FindWorkerFilter { get; set; }
        public List<SkillViewModel> SkillsList { get; set; }
        public IEnumerable<SelectListItem> CountriesList { get; set; }
        public IEnumerable<SelectListItem> TimeZoneList { get; set; }
        public FindWorkerViewModel()
        {
            SkillsList = new List<SkillViewModel>();
            CountriesList = new List<SelectListItem>();
            TimeZoneList = new List<SelectListItem>();
        }
    }

    public class FindWorkerFilter
    {
        [Display(Name = "Worker name")]
        [StringLength(50,ErrorMessage="Max 50 characters allowed")]
        public string WorkerName { get; set; }

        public string[] CountryNameList { get; set; }

        [Display(Name = "Country")]
        public string CountryNames { get; set; }

        public long[] SkillIdsList { get; set; }
        [Display(Name = "Skills")]
        public string SkillIds { get; set; }

        [Display(Name = "Time zone")]
        public string TimeZone { get; set; }

        [Display(Name = "Hourly rate")]
        [Range(5, 1000, ErrorMessage = "Hourly rate should be between {0} & {1}")]
        public decimal HourlyRate { get; set; }

        [Display(Name = "Rating")]
        [Range(0,5,ErrorMessage="Rating could be between 0-5")]
        public decimal Rating { get; set; }
    }
}
