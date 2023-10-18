using PS.HireRocks.Model.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PS.HireRocks.Model
{
    public class PostJobViewModel
    {
        public long? JobId { get; set; }

        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string JobTitle { get; set; }

        [Display(Name = "Job Type")]
        [Required(ErrorMessage = "Please select {0}")]
        public long? JobTypeId { get; set; }

        [Display(Name = "Time unit")]
        [Required(ErrorMessage = "Please select {0}")]
        public long? TimeUnitId { get; set; }

        [Display(Name = "Worker type")]
        [Required(ErrorMessage = "Please select {0}")]
        public long? WorkerTypeId { get; set; }

        [Display(Name = "Experience level")]
        [Required(ErrorMessage = "Please select {0}")]
        public long? ExperienceLevelId { get; set; }

        [Display(Name = "Job category")]
        [Required(ErrorMessage = "Please select {0}")]
        public long? JobCategoryId { get; set; }

        [Display(Name = "Job sub category")]
        [Required(ErrorMessage = "Please select {0}")]
        public long? JobSubCategoryId { get; set; }

        [Display(Name = "Skills")]
        [Required(ErrorMessage = "Please select {0}")]
        public string SkillRequiredForJobIds { get; set; }

        [Display(Name = "Estimate duration")]
        [Required(ErrorMessage = "Please select {0}")]
        public decimal? EstimateDuratoion { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? JobStartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime? JobEndDate { get; set; }

        public string Description { get; set; }
        public string JobAttachmentsXML { get; set; }
        public string ClientId { get; set; }
        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
        [Display(Name = "Hiring closed?")]
        public bool IsHiringClosed { get; set; }

        [Display(Name = "Min Prefered Rate")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal? Min_PRF_Rate { get; set; }

        [Display(Name = "Max Prefered Rate")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal? Max_PRF_Rate { get; set; }

        [Display(Name = "Fixed Rate")]
        [Required(ErrorMessage = "{0} is required")]
        public decimal? FixedRate { get; set; }

        [Display(Name = "Prefered Locality")]
        [Required(ErrorMessage = "{0} is required")]
        public string Locality_PRF { get; set; }

        public InsertUpdateAttachmentsViewModel InsertUpdateAttachmentsViewModel { get; set; }
        public List<SelectListItem> JobTypeList { get; set; }
        public List<SelectListItem> JobCategoryList { get; set; }
        public List<SelectListItem> JobSubCategoryList { get; set; }
        public List<JobSubCategoryViewModel> AllJobSubCategoryList { get; set; }
        public List<JobAttachmentsViewModel> JobAttachmentsList { get; set; }
        public List<SkillViewModel> SkillList { get; set; }
        public List<SelectListItem> WorkerTypeList { get; set; }
        public List<SelectListItem> ExperienceLevelList { get; set; }
        public List<SelectListItem> TimeUnits { get; set; }
        public List<SelectListItem> CountriesList { get; set; }
        public List<HttpPostedFileBase> attachments { get; set; }

        public PostJobViewModel()
        {
            JobTypeList = new List<SelectListItem>();
            JobCategoryList = new List<SelectListItem>();
            JobSubCategoryList = new List<SelectListItem>();
            JobAttachmentsList = new List<JobAttachmentsViewModel>();
            SkillList = new List<SkillViewModel>();
            WorkerTypeList = new List<SelectListItem>();
            ExperienceLevelList = new List<SelectListItem>();
            TimeUnits = new List<SelectListItem>();
            AllJobSubCategoryList = new List<JobSubCategoryViewModel>();
            JobStartDate = JobEndDate = DateTime.Now;
            InsertUpdateAttachmentsViewModel = new InsertUpdateAttachmentsViewModel();
        }
    }

    public class JobTypeViewModel
    {
        public long JobTypeId { get; set; }
        public string JobTypeName { get; set; }
    }

    public class WorkerTypeViewModel
    {
        public long WorkerTypeId { get; set; }
        public string WorkerTypeName { get; set; }
    }
}
