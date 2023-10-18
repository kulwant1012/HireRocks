using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using PS.HireRocks.Model;
using System.Configuration;
using System.Net;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.WebApi.Helpers;
using PS.HireRocks.Data.Database;
using System.Linq;
using Microsoft.AspNet.Identity;
using PS.HireRocks.WebApi.Models;
using System.Globalization;
using PS.HireRocks.Data.Helpers;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Claims;
using System.Net.Mail;
using System.Drawing.Drawing2D;
using System.Web.Http.ModelBinding;

namespace PS.HireRocks.WebApi.Controllers
{
    
    [RoutePrefix("api/Account")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController   {
        

        public AccountController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
           // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<object> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.UserName, model.Password);

                if (user != null && user.IsEmailVerified)
                {                     
                    using (var client = new HttpClient())
                    {
                        var form = new Dictionary<string, string>
                        {
                             {"grant_type", "password"},
                             {"username", model.UserName},
                             {"password", model.Password},
                        };
                        var tokenEndpoint = ConfigurationManager.AppSettings["ServerAddress"] + "/oauth/token";

                        var tokenResponse = client.PostAsync(ConfigurationManager.AppSettings["ServerAddress"] + "/oauth/token", new FormUrlEncodedContent(form)).Result;

                        if (tokenResponse.IsSuccessStatusCode)
                        {                           
                            var token = tokenResponse.Content.ReadAsStringAsync().Result;
                            return token;                        
                        }
                        else
                        {                           
                            return BadRequest();
                        }                                            
                    }                    
                }
                if (user != null && !user.IsEmailVerified)
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Your email not verified yet.");
              
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid username or password.");
                }
            }           
            return Unauthorized();
        } 

        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        [HttpGet]
        [Route("Register")]
        [AllowAnonymous]
        public ApiRegisterViewModel Register()
        {
            var registerViewModel = new ApiRegisterViewModel();
            registerViewModel.RolesList = GetRolesList();
            registerViewModel.AccountTypeList = GetAccountTypeList();
            return registerViewModel;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public async Task<object> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid && model.IsUserAgreed)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    IsEmailVerified = false,
                    EmailVerificationCode = Guid.NewGuid().ToString()
                };
                UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager) { };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var selected_account = GetAccountTypeList().FirstOrDefault(x => x.Value == model.AccountTypeId);
                    var role = GetRolesList().FirstOrDefault(x => x.Text == selected_account.Text);
                    var roleResult = await UserManager.AddToRoleAsync(user.Id, role.Value);
                    new UserRepository().InsertUserAccountType(model.AccountTypeId, user.Id);
                    if (roleResult.Succeeded)
                    {
                        string body = string.Format("Hello " + model.FirstName + " " + model.LastName + ", <br/>Thanks for registration with Hire Rocks, please click on the below link to complete your registration:<br/> <a href=" +
                            ConfigurationManager.AppSettings[WebsiteConstants.ServerAddress] + "/api/Account/VerifyEmailAddress?emailVerificationCode=" + user.EmailVerificationCode + " title='User Email Confirm'>"
                            + ConfigurationManager.AppSettings[WebsiteConstants.ServerAddress] + "/api/Account/VerifyEmailAddress?emailVerificationCode=" + user.EmailVerificationCode) + "</a>";
                        await new EmailHelper().SendEmailNotification(model.Email, "Confirm email address", body);                      
                        model.IsRegisterationSuccessFull = true;
                        return model;
                    }
                    else
                         return Request.CreateResponse(HttpStatusCode.NotFound, roleResult); 
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, result);
                }
            }
            // If we got this far, something failed, redisplay form          
            return model;
        }

        [HttpGet]
        [Route("CompleteProfile")]
        [Authorize]
        public async Task<UserProfileViewModel> CompleteProfile()
        {
            UserProfileViewModel userProfileViewModel = null;
            IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }
            else
            {
                userProfileViewModel = new UserRepository().GetCompleteProfileScreenData(user.Id);
                userProfileViewModel.CountriesList = GetCountriesList().ToList();
                userProfileViewModel.TimeZoneList = GetTimeZoneList().ToList();
                userProfileViewModel.CertificationsList = userProfileViewModel.CertificationsList ?? new List<CertificationViewModel>();
                userProfileViewModel.IsUserWorker = await UserManager.IsInRoleAsync(user.Id, RoleConstants.Worker);

            }
            return userProfileViewModel;
        }

        [HttpPost]
        [Route("CompleteProfile")]
        [Authorize]
        public async Task<object> CompleteProfile(UserProfileViewModel model)
        {

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var userProfileViewModel = new UserRepository().GetCompleteProfileScreenData(user.Id);
            if (user != null)
            {
                model.UserId = user.Id;
                model.LanguageIds = string.Join(",", model.LanguageList.Where(x => x.IsSelected).Select(x => x.LanguageId));

                if (!model.IsUserWorker)
                {
                    ModelState.Remove("SkillIds");
                    ModelState.Remove("JobSubCategoriesIds");
                    ModelState.Remove("HourlyRate");
                }
                else
                {
                    if (string.IsNullOrEmpty(model.JobSubCategoriesIds))
                        ModelState.AddModelError(string.Empty, "Please select Job categories from provided options only");
                    if (string.IsNullOrEmpty(model.SkillIds))
                        ModelState.AddModelError(string.Empty, "Please select Language from provided options only");
                    model.SkillIds = string.Join(",", model.SkillList.Where(x => x.IsSelected).Select(x => x.SkillId));
                    List<string> subCategoriesIds = new List<string>();
                    foreach (var item in model.JobCategoryList)
                    {
                        subCategoriesIds.AddRange(item.JobSubCategoryList.Where(x => x.IsSelected).Select(x => x.JobSubCategoryId.ToString()).ToList());
                    }
                    model.JobSubCategoriesIds = string.Join(",", subCategoriesIds);
                }

                if (string.IsNullOrEmpty(model.LanguageIds))
                    ModelState.AddModelError(string.Empty, "Please select Language from provided options only");
                if (model.profileImages != null)
                {
                    string fileExtension = Path.GetExtension(model.profileImages.FileName).ToLower();
                    if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
                        ModelState.AddModelError(string.Empty, "Please select an Image to set it as profile pic");
                }
                if (model.introductionVideo != null)
                {
                    string fileExtension = Path.GetExtension(model.introductionVideo.FileName).ToLower();
                    if (fileExtension != ".mp4")
                        ModelState.AddModelError(string.Empty, "Please select MP4 format video only");
                }
                if (model.Gender != GenderConstants.Male && model.Gender != GenderConstants.Female)
                    ModelState.AddModelError(string.Empty, "Please select valid option for Gender");

                if (ModelState.IsValid)
                {
                    if (model.profileImages != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + model.profileImages.FileName;
                        using (Image image = Image.FromStream(model.profileImages.InputStream))
                        {
                            using (var fullImage = image.GetThumbnailImage(600, 500, null, new System.IntPtr()))
                            using (var thumbNailImage = image.GetThumbnailImage(128, 128, null, new System.IntPtr()))
                            {
                                string profileFullImageFolder = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[WebsiteConstants.ProfileFullImageFolder]);
                                string profileThumbnailImageFolder = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[WebsiteConstants.profileThumbnailImageFolder]);
                                fullImage.Save(profileFullImageFolder + fileName, ImageFormat.Jpeg);
                                thumbNailImage.Save(profileThumbnailImageFolder + fileName, ImageFormat.Jpeg);
                            }
                        }
                        model.ProfileImage = fileName;
                    }
                    else if (string.IsNullOrEmpty(model.ProfileImage))
                    {
                        if (model.Gender == GenderConstants.Male)
                            model.ProfileImage = WebsiteConstants.DefaultProfilePicMale;
                        else
                            model.ProfileImage = WebsiteConstants.DefaultProfilePicFemale;
                    }
                    if (model.introductionVideo != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + model.introductionVideo.FileName;
                        model.introductionVideo.SaveAs(System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[WebsiteConstants.IntroductionVideoFolder]) + fileName);
                        model.VideoIntroduction = fileName;
                    }
                    var educationList = new List<EducationViewModel>();
                    foreach (var item in model.EducationList)
                    {
                        if (item.DegreeTypeId.HasValue && item.DegreeEndDate.HasValue && item.DegreeStartDate.HasValue && !string.IsNullOrEmpty(item.DegreeName) && item.Percentage.HasValue)
                            educationList.Add(item);
                    }
                    if (educationList.Count > 0)
                        model.EducationDetailXML = new ConvertObjectToXML().ConvertObjectToXml(educationList);
                    if (userProfileViewModel.CertificationsList.Count > 0)
                    {
                        userProfileViewModel.CertificationsList.RemoveAll(m => m.IsDeleted && m.HasTempCertificationId);
                        model.CertificationDetailXML = new ConvertObjectToXML().ConvertObjectToXml(userProfileViewModel.CertificationsList);
                    }

                    new UserRepository().InsertUpdateUserProfile(model);

                    return model;
                }
                return BadRequest(ModelState);        
            }
            else
                ModelState.AddModelError(string.Empty, "Please login to complete your profile");
            return model;
        }

        IEnumerable<System.Web.Mvc.SelectListItem> GetTimeZoneList()
        {
            return from timeZone in TimeZoneInfo.GetSystemTimeZones() select new System.Web.Mvc.SelectListItem { Text = timeZone.DisplayName, Value = timeZone.DisplayName };
        }
        IEnumerable<System.Web.Mvc.SelectListItem> GetCountriesList()
        {
            List<System.Web.Mvc.SelectListItem> countriesList = new List<System.Web.Mvc.SelectListItem>();
            System.Web.Mvc.SelectListItem country;
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo regionInfo = new RegionInfo(culture.LCID);
                country = new System.Web.Mvc.SelectListItem { Text = regionInfo.EnglishName, Value = regionInfo.EnglishName };
                if (!countriesList.Exists(x => x.Value == country.Value))
                    countriesList.Add(country);
            }
            return countriesList.OrderBy(x => x.Value);
        }
      
        IEnumerable<System.Web.Mvc.SelectListItem> GetAccountTypeList()
        {
            return new RoleRepository().GetAccountTypesView().Select(x => new System.Web.Mvc.SelectListItem { Text = x.AccountTypeName, Value = x.AccountTypeId.ToString() });
        }
            
        [Route("GetRolesList")]
        public IEnumerable<System.Web.Mvc.SelectListItem> GetRolesList()
        {
            return new RoleRepository().GetAllRoles().Select(x => new System.Web.Mvc.SelectListItem { Text = x.Name, Value = x.Name });
        }
        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("VerifyEmailAddress")]     
        public IHttpActionResult VerifyEmailAddress(string emailVerificationCode)
        {
            if (!string.IsNullOrEmpty(emailVerificationCode) && new UserRepository().VerifyEmailAddress(emailVerificationCode))
                return Ok(new { SuccessMessage = "You email address is verified successfully" });
            else
            {
                return BadRequest("Your email address not registered with Hire Rocks!");               
            }
        }

        [AllowAnonymous]   
        [HttpGet]
        [Route("GetLicenseAgreement")]
        public IHttpActionResult GetLicenseAgreement()
        {
            ///to do : Need to apply logic to display diff. agreements to  diff type of users
            return Ok(new LicenseAgreementRepository().GetLicenseAgreementById(1));
        }

        //
        // POST: /Account/Disassociate
        [HttpPost]
        [Authorize]
        [Route("Disassociate")]
        public async Task<IHttpActionResult> Disassociate(string loginProvider, string providerKey)
        {
            ManageMessageId? message = null;
            IdentityResult result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return Ok(message);
        }        
      
        [HttpPost]       
        [Authorize]
        [Route("Manage")]
        public async Task<IHttpActionResult> Manage(ManageUserViewModel model)
        {
            bool hasPassword = HasPassword();        
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return Ok(new { SuccessMessage = "You password has been changed successfully" });
                       
                    }
                    else
                    {
                        return BadRequest(result.ToString());
                    }
                }
            }
            else
            {
                // User does not have a password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                    if (result.Succeeded)
                    {
                        return Ok(new { SuccessMessage = "You password has been added successfully" });
                    }
                    else
                    {
                        return BadRequest(result.ToString());
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return BadRequest();
        }
       
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public IHttpActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return Ok(returnUrl);
        }        

        [AllowAnonymous]
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IHttpActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                string forgotPasswordToken = Guid.NewGuid().ToString();
                var result = new UserRepository().SetForgotPasswordToken(forgotPasswordToken, model.Email);
                if (result != null)
                {
                    string emailBody = string.Format("Hello " + result.FirstName + " " + result.LastName + ", <br/>"
                        + "Recently you requested Password reset, please click below link to reset password<br/>"
                        + "<a href=" + ConfigurationManager.AppSettings["ServerAddress"] + "Account/ResetPassword?forgotPasswordToken=" + forgotPasswordToken + ">" +
                        ConfigurationManager.AppSettings["ServerAddress"] + "Account/ResetPassword?forgotPasswordToken=" + forgotPasswordToken + "</a>");
                    await new EmailHelper().SendEmailNotification(model.Email, "Password reset", emailBody);
                    model.IsSuccess = true;
                    return Ok(new { SuccessMessage = "email is sent successfully for forgot password"});
                }
                else
                    return BadRequest("Provided email not registered with Hire Rocks");                   
            }
            return BadRequest("model state is not valid");
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("ResetPassword")]
        public IHttpActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(model.ForgotPasswordToken))
            {
                var password = UserManager.PasswordHasher.HashPassword(model.NewPassword);
                if (new UserRepository().ResetPassword(model.ForgotPasswordToken, password))
                    return Ok(new { SuccessMessage = "password is reset successfully" });
                else
                    ModelState.AddModelError(string.Empty, "Invalid reset pasword token provided");
            }
            if (string.IsNullOrEmpty(model.ForgotPasswordToken))
                return BadRequest("Reset password token not provided");            
            return BadRequest("model state is not valid");
        }        

        [Authorize]
        [HttpGet]
        [Route("GetCertifications")]

        public IHttpActionResult GetCertifications()
        {
            var user =  UserManager.FindByIdAsync(User.Identity.GetUserId());
            var userProfileViewModel = new UserRepository().GetCompleteProfileScreenData(User.Identity.GetUserId());
            userProfileViewModel = new UserProfileViewModel();
            userProfileViewModel.CertificationsList = new List<CertificationViewModel>();           
            return Ok(userProfileViewModel.CertificationsList);
        }

        [HttpPost]
        [Authorize]
        [Route("AddCertification")]
        public IHttpActionResult AddCertification(CertificationViewModel model)
        {
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            var userProfileViewModel = new UserRepository().GetCompleteProfileScreenData(User.Identity.GetUserId());

            int certificationId = 0;
            do
            {
                certificationId = new Random().Next(1, int.MaxValue);
            }
            while (userProfileViewModel.CertificationsList.FirstOrDefault(m => m.CertificationId == certificationId) != null);
            model.CertificationId = certificationId;
            model.HasTempCertificationId = true;
            if (ModelState.IsValid)
                userProfileViewModel.CertificationsList.Add(model);
            return Ok(model);
        }

        [HttpPost]
        [Authorize]
        [Route("DeleteCertification")]
        public IHttpActionResult DeleteCertification(CertificationViewModel model)
        {
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            var userProfileViewModel = new UserRepository().GetCompleteProfileScreenData(User.Identity.GetUserId());
            userProfileViewModel.CertificationsList.Remove(userProfileViewModel.CertificationsList.FirstOrDefault(x => x.CertificationId == x.CertificationId));
            return Ok(model);
        }

        [HttpPost]
        [Authorize]
        [Route("UpdateCertification")]
        public IHttpActionResult UpdateCertification(CertificationViewModel model)
        {
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            var userProfileViewModel = new UserRepository().GetCompleteProfileScreenData(User.Identity.GetUserId());
            var certification = userProfileViewModel.CertificationsList.FirstOrDefault(x => x.CertificationId == model.CertificationId);
            if (certification != null)
            {
                certification.CertificationId = model.CertificationId;
                certification.CertificationName = model.CertificationName;
                certification.CertificationNumber = model.CertificationNumber;
                certification.CertificationYear = model.CertificationYear;
                certification.HasTempCertificationId = model.HasTempCertificationId;
                certification.IsDeleted = model.IsDeleted;
                certification.IsUpdated = true;
            }
            return Ok(model);
        } 
       

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }      

    }
}
