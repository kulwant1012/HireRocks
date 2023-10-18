using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Compare = System.ComponentModel.DataAnnotations.CompareAttribute;

using PS.HireRocks.Model.Validations;

namespace PS.HireRocks.Model
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "First name")]
        [StringLength(50, ErrorMessage = "{0} should be less than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Last name")]
        [StringLength(50, ErrorMessage = "{0} should be less than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(50, ErrorMessage = "{0} should be less than 50 characters")]
        [Remote("IsEmailAddressAlreadyExists", "Account", AdditionalFields = "Email", ErrorMessage = "Email already Exists")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "User name")]
        [StringLength(50, ErrorMessage = "{0} should be less than 50 characters")]
        [Remote("IsUserNameAlreadyExists", "Account", AdditionalFields = "UserName", ErrorMessage = "Username already taken")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z]).{0,100}$", ErrorMessage = "Password must contain one digit and an uppercase letter")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [StringLength(50, ErrorMessage = "{0} should be less than 50 characters")]
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Please select {0}")]
        //[Display(Name = "User type")]
        //[StringLength(50, ErrorMessage = "{0} should be less than 50 characters")]
        //public string RoleId { get; set; }

        //[Required(ErrorMessage = "Please select {0}")]
        [Display(Name = "Account type")]
        public string AccountTypeId { get; set; }

        [Required(ErrorMessage = "Please accept terms & conditions")]
        [Display(Name = "I Agree")]
        [BoolValidator(ErrorMessage = "Please accept terms & conditions")]
        public bool IsUserAgreed { get; set; }

        //public IEnumerable<SelectListItem> RolesList { get; set; }
        public IEnumerable<SelectListItem> AccountTypeList { get; set; }

        public bool IsRegisterationSuccessFull { get; set; }
    }
}
