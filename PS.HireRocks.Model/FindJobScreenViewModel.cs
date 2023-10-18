using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PS.HireRocks.Model
{
    public class FindJobScreenViewModel
    {
        public FindJobFilters FindJobFilters { get; set; }
        public IEnumerable<SelectListItem> JobCategoriesList { get; set; }
        public IEnumerable<SelectListItem> jobList { get; set; }
        public List<SelectListItem> JobSubCategoriesList { get; set; }
        public List<JobSubCategoryViewModel> AllJobSubCategoryList { get; set; }
        public IEnumerable<SelectListItem> JobTypeList { get; set; }
        public IEnumerable<SelectListItem> ExperienceLevelList { get; set; }
        public ApplyForJobViewModel ApplyForJobViewModel { get; set; }
        public decimal? WorkerRate { get; set; }
        public FindJobScreenViewModel()
        {
          
            JobCategoriesList = new List<SelectListItem>();
            JobSubCategoriesList = new List<SelectListItem>();
            AllJobSubCategoryList = new List<JobSubCategoryViewModel>();
            JobTypeList = new List<SelectListItem>();
            ExperienceLevelList = new List<SelectListItem>();
        }
    }

    public class FindJobFilters
    {
        [Display(Name = "Job name")]
        [StringLength(50, ErrorMessage = "Max 50 characters allowed")]
        public string JobName { get; set; }

        [Display(Name = "Job category")]
        public long? JobCategoryId { get; set; }
     
        public long[] JobSubCategoriesList { get; set; }

        [Display(Name = "Job sub category")]
        public string JobSubCategoriesIds { get; set; }

        [Display(Name = "Job type")]
        public long? JobTypeId { get; set; }

        [Display(Name = "Experience level")]
        public long? ExperienceLevelId { get; set; }

        public string WorkerId { get; set; }
        public long? JobBidId { get; set; }
       
    }
}
