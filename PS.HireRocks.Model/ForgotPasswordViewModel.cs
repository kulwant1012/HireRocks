using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(50, ErrorMessage = "{0} should be less than 50 characters")]
        public string Email { get; set; }

        public bool IsSuccess { get; set; }
    }
}
