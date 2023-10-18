using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace PS.HireRocks.Model
{
    public class UserProfileViewModel
    {
        public string UserId { get; set; }
        public long? UserProfileId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Skills")]
        public string SkillIds { get; set; }

        [Required(ErrorMessage = "Select at least one {0}")]
        [Display(Name = "Language")]
        public string LanguageIds { get; set; }

        [Required(ErrorMessage = "Select at least one {0}")]
        [Display(Name = "Job category")]
        public string JobSubCategoriesIds { get; set; }

        [Display(Name = "Profile Title")]
        public string ProfileTitle { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Hourly rate")]
        public decimal? HourlyRate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Address")]
        public string Addresss1 { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Country")]
        public string Country1 { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "City")]
        public string City1 { get; set; }

        public string Addresss2 { get; set; }
        public string Country2 { get; set; }
        public string City2 { get; set; }

        [Display(Name = "Cell phone")]
        [Required(ErrorMessage = "{0} is required")]
        [Phone(ErrorMessage = "Please enter valid phone number")]
        public string CellPhone { get; set; }

        [Display(Name = "Work phone")]
        public string WorkPhone { get; set; }

        [Display(Name = "Home phone")]
        public string HomePhone { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Time zone")]
        public string TimeZone { get; set; }

        [Display(Name = "Profile image")]
        public string ProfileImage { get; set; }

        [Display(Name = "Same as address 1")]
        public bool SameAsAddress1 { get; set; }

        [Display(Name = "I am")]
        [Required(ErrorMessage = "Please select gender")]
        public string Gender { get; set; }

        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Video introduction")]
        public string VideoIntroduction { get; set; }

        public string EducationDetailXML { get; set; }
        public string CertificationDetailXML { get; set; }
        public string Email { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsUserWorker { get; set; }

        public List<CertificationViewModel> CertificationsList { get; set; }
        public List<JobCategoryViewModel> JobCategoryList { get; set; }
        public List<SelectListItem> CountriesList { get; set; }
        public List<SelectListItem> TimeZoneList { get; set; }
        public List<LanguageViewModel> LanguageList { get; set; }
        public List<SkillViewModel> SkillList { get; set; }
        public List<EducationViewModel> EducationList { get; set; }

        public HttpPostedFileBase profileImages { get; set; }

        public HttpPostedFileBase introductionVideo { get; set; }


    }

    public class EducationViewModel
    {
        public long? EducationId { get; set; }

        [Display(Name = "Degree Type")]
        public long? DegreeTypeId { get; set; }

        [Display(Name = "Percentage")]
        public decimal? Percentage { get; set; }

        [Display(Name = "Degree type")]
        public string DegreeTypeName { get; set; }

        [Display(Name = "Degree")]
        public string DegreeName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime? DegreeStartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime? DegreeEndDate { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class JobCategoryViewModel
    {
        public long JobCategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<JobSubCategoryViewModel> JobSubCategoryList { get; set; }
        public JobCategoryViewModel()
        {
            JobSubCategoryList = new List<JobSubCategoryViewModel>();
        }
    }

    public class JobSubCategoryViewModel
    {
        public long JobSubCategoryId { get; set; }
        public long? JobCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool IsSelected { get; set; }
    }

    public class LanguageViewModel
    {
        public long LanguageId { get; set; }
        public string LanguageName { get; set; }
        public bool IsSelected { get; set; }
    }

    public class SkillViewModel
    {
        public long SkillId { get; set; }
        public string SkillName { get; set; }
        public bool IsSelected { get; set; }
    }

    public class DegreeTypeViewModel
    {
        public long DegreeTypeId { get; set; }
        public string DegreeTypeName { get; set; }
    }

    public class CertificationViewModel
    {
        public long CertificationId { get; set; }

        [Required(ErrorMessage = "Certification number is required")]
        [StringLength(100, ErrorMessage = "Max 100 characters allowed")]
        public string CertificationNumber { get; set; }

        [Required(ErrorMessage = "Certification name is required")]
        [StringLength(100, ErrorMessage = "Max 100 characters allowed")]
        public string CertificationName { get; set; }

        [Required(ErrorMessage = "Certification date is required")]
        [UIHint("DatePicker")]
        public DateTime? CertificationYear { get; set; }
        public bool HasTempCertificationId { get; set; }
        [Display(Name = "Is deleted")]
        public bool IsDeleted { get; set; }
        public bool IsUpdated { get; set; }
    }
}
