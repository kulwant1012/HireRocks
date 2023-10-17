using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using PS.HireRocks.Web.Models;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Data.Helpers;
using PS.HireRocks.Model;
using System.Net.Mail;
using System.Configuration;
using PS.HireRocks.Web.Helpers;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using PS.HireRocks.Data.Database;
using System.Net;

namespace PS.HireRocks.Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            string decoded = WebUtility.HtmlDecode(Request.QueryString["text"]);
            var url = Request.QueryString["text"];
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.ReturnUrl2 = url;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.UserName, model.Password);
             
                if (user != null && user.IsEmailVerified)
                {
                    Session[SessionNameConstants.LogedInUserSession] = user;
                    if (user.IsProfileCompleted)
                    {
                        await SignInAsync(user, model.RememberMe);
                        return RedirectToLocal(returnUrl);
                    }
                    else
                        return RedirectToAction("CompleteProfile");
                }
                if (user != null && !user.IsEmailVerified)
                    ModelState.AddModelError("", "Your email not verified yet.");
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            var registerViewModel = new RegisterViewModel();
            
           
            registerViewModel.AccountTypeList = GetAccountTypeList();
            return View(registerViewModel);
        }

        IEnumerable<SelectListItem> GetRolesList()
        {
        return new RoleRepository().GetAllRoles().Select(x => new SelectListItem { Text = x.Name, Value = x.Name });
        }

        IEnumerable<SelectListItem> GetAccountTypeList()
        {
            return new RoleRepository().GetAccountTypesView().Select(x => new SelectListItem { Text = x.AccountTypeName, Value = x.AccountTypeId.ToString() });
        }

        IEnumerable<SelectListItem> GetCountriesList()
        {
            List<SelectListItem> countriesList = new List<SelectListItem>();
            SelectListItem country;
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo regionInfo = new RegionInfo(culture.LCID);
                country = new SelectListItem { Text = regionInfo.EnglishName, Value = regionInfo.EnglishName };
                 if (!countriesList.Exists(x=>x.Value==country.Value))
                     countriesList.Add(country);
            }
            return countriesList.OrderBy(x=>x.Value);
        }

        IEnumerable<SelectListItem> GetTimeZoneList()
        {
            return from timeZone in TimeZoneInfo.GetSystemTimeZones() select new SelectListItem { Text = timeZone.DisplayName, Value = timeZone.DisplayName };
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
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
                            ConfigurationManager.AppSettings[WebsiteConstants.ServerAddress] + "/Account/VerifyEmailAddress?emailVerificationCode=" + user.EmailVerificationCode+" title='User Email Confirm'>"
                            + ConfigurationManager.AppSettings[WebsiteConstants.ServerAddress] + "/Account/VerifyEmailAddress?emailVerificationCode=" + user.EmailVerificationCode) + "</a>";
                        await new EmailHelper().SendEmailNotification(model.Email, "Confirm email address", body);
                        ViewBag.Message = "Your account registered successfully, please login into your email to verify email address";
                        model.IsRegisterationSuccessFull = true;
                        return View(model);
                    }
                    else
                        AddErrors(roleResult);
                }
                else
                {
                    AddErrors(result);
                }
            }          
     
            model.AccountTypeList = GetAccountTypeList();
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult VerifyEmailAddress(string emailVerificationCode)
        {
            if (!string.IsNullOrEmpty(emailVerificationCode) && new UserRepository().VerifyEmailAddress(emailVerificationCode))
                return RedirectToAction("Login");
            else
            {
                ViewBag.Message = "Your email address not registered with Hire Rocks";
                return View(); 
            }
        }        

        [AllowAnonymous]
        public JsonResult GetLicenseAgreement()
        {
            ///to do : Need to apply logic to display diff. agreements to  diff type of users
            return Json(new LicenseAgreementRepository().GetLicenseAgreementById(1), JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Account/Disassociate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
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
            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
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
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //[AllowAnonymous]
        //public async Task<ActionResult> GetEducationsGridData([DataSourceRequest] DataSourceRequest request)
        //{
        //    var user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
        //    IEnumerable<EducationViewModel> educationsList = new List<EducationViewModel>();
        //    if (user != null)
        //        educationsList = await ExecuteFunction(() => new UserRepository().GetEducationDetailsByUserId(user.Id));
        //    return Json(educationsList.ToDataSourceResult(request));
        //}

        //[AllowAnonymous]
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult AddEducation([DataSourceRequest] DataSourceRequest request, EducationViewModel model)
        //{
        //    UserProfileViewModel userProfileViewModel = (UserProfileViewModel)Session[SessionNameConstants.CompleteProfileSession];
        //    if (model != null && ModelState.IsValid)
        //    {
        //        int educationId = 0;
        //        do
        //        {
        //            educationId = new Random().Next(1, int.MaxValue);
        //        }
        //        while (userProfileViewModel.EducationList.FirstOrDefault(m => m.EducationId == educationId) != null);
        //        model.EducationId = educationId;
        //        model.HasTemporaryEducationId = true;
        //        userProfileViewModel.EducationList.Add(model);
        //    }
        //    return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        //}

        //[AllowAnonymous]
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult DeleteEducation([DataSourceRequest] DataSourceRequest request, EducationViewModel model)
        //{
        //    UserProfileViewModel userProfileViewModel = (UserProfileViewModel)Session[SessionNameConstants.CompleteProfileSession];
        //    if (model != null && ModelState.IsValid)
        //        userProfileViewModel.EducationList.Remove(userProfileViewModel.EducationList.FirstOrDefault(x => x.EducationId == model.EducationId));
        //    return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        //}

        //[AllowAnonymous]
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult UpdateEducation([DataSourceRequest] DataSourceRequest request, EducationViewModel model)
        //{
        //    if (model != null && ModelState.IsValid)
        //    {
        //        UserProfileViewModel userProfileViewModel = (UserProfileViewModel)Session[SessionNameConstants.CompleteProfileSession];
        //        var educationObject = userProfileViewModel.EducationList.FirstOrDefault(x => x.EducationId == model.EducationId);
        //        if (educationObject != null)
        //        {
        //            educationObject.DegreeEndDate = model.DegreeEndDate;
        //            educationObject.DegreeName = model.DegreeName;
        //            educationObject.DegreeStartDate = model.DegreeStartDate;
        //            educationObject.DegreeTypeId = model.DegreeTypeId;
        //            educationObject.DegreeTypeName = model.DegreeTypeName;
        //            educationObject.EducationId = model.EducationId;
        //            educationObject.Grades = model.Grades;
        //        }
        //    }
        //    return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        //}


        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var user = await UserManager.FindAsync(loginInfo.Login);
            if (user != null)
            {
               
                await SignInAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // If the user does not have an account, then prompt the user to create an account
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = loginInfo.DefaultUserName });
            }
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                string forgotPasswordToken = Guid.NewGuid().ToString();
                var result = new UserRepository().SetForgotPasswordToken( forgotPasswordToken,model.Email);
                if (result != null)
                {
                    string emailBody = string.Format("Hello " + result.FirstName + " " + result.LastName + ", <br/>"
                        + "Recently you requested Password reset, please click below link to reset password<br/>"
                        + "<a href=" + ConfigurationManager.AppSettings["ServerAddress"] + "Account/ResetPassword?forgotPasswordToken=" + forgotPasswordToken + ">" +
                        ConfigurationManager.AppSettings["ServerAddress"] + "Account/ResetPassword?forgotPasswordToken=" + forgotPasswordToken + "</a>");
                    await new EmailHelper().SendEmailNotification(model.Email, "Password reset", emailBody);
                    model.IsSuccess = true;
                }
                else
                    ModelState.AddModelError(string.Empty, "Provided email not registered with Hire Rocks");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string forgotPasswordToken)
        {
            return View(new ResetPasswordViewModel { ForgotPasswordToken=forgotPasswordToken});
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(model.ForgotPasswordToken))
            {
                var password = UserManager.PasswordHasher.HashPassword(model.NewPassword);
                if (new UserRepository().ResetPassword(model.ForgotPasswordToken, password))
                    return RedirectToAction("Login");
                else
                    ModelState.AddModelError(string.Empty, "Invalid reset pasword token provided");
            }
            if (string.IsNullOrEmpty(model.ForgotPasswordToken))
                ModelState.AddModelError(string.Empty, "Reset password token not provided");
            return View(model);
        }

        [AllowAnonymous]
        public async Task<ActionResult> CompleteProfile()
        {
            UserProfileViewModel userProfileViewModel = null;
            var userSession = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            if (userSession == null)
                ModelState.AddModelError(string.Empty, "Please login to complete profile");
            else
            {
                userProfileViewModel = new UserRepository().GetCompleteProfileScreenData(userSession.Id);
                userProfileViewModel.CountriesList = GetCountriesList().ToList();
                userProfileViewModel.TimeZoneList = GetTimeZoneList().ToList();
                userProfileViewModel.CertificationsList = userProfileViewModel.CertificationsList ?? new List<CertificationViewModel>();
                userProfileViewModel.IsUserWorker = await UserManager.IsInRoleAsync(userSession.Id, RoleConstants.Worker);
                Session[SessionNameConstants.CompleteProfileSession] = userProfileViewModel;
            }
            return View(userProfileViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CompleteProfile(UserProfileViewModel model, HttpPostedFileBase profileImage, HttpPostedFileBase introductionVideo)
        {

            var userSession = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            var userProfileViewModel = (UserProfileViewModel)Session[SessionNameConstants.CompleteProfileSession];
            if (userSession != null)
            {
                model.UserId = userSession.Id;
                model.LanguageIds = string.Join(",", model.LanguageList.Where(x => x.IsSelected).Select(x => x.LanguageId));

                if (!model.IsUserWorker)
                {
                    ModelState.Remove("SkillIds");
                    ModelState.Remove("JobSubCategoriesIds");
                    ModelState.Remove("HourlyRate");
                    ModelState.Remove("EducationList");
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
                    var educationList = new List<EducationViewModel>();
                    foreach (var item in model.EducationList)
                    {
                        if (item.DegreeTypeId.HasValue && item.DegreeEndDate.HasValue && item.DegreeStartDate.HasValue && !string.IsNullOrEmpty(item.DegreeName) && item.Percentage.HasValue)
                            educationList.Add(item);
                    }
                    if (educationList.Count > 0)
                        model.EducationDetailXML = new ConvertObjectToXML().ConvertObjectToXml(educationList);
                }

                if (string.IsNullOrEmpty(model.LanguageIds))
                    ModelState.AddModelError(string.Empty, "Please select Language from provided options only");
                if (profileImage != null)
                {
                    string fileExtension = Path.GetExtension(profileImage.FileName).ToLower();
                    if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
                        ModelState.AddModelError(string.Empty, "Please select an Image to set it as profile pic");
                }
                if (introductionVideo != null)
                {
                    string fileExtension = Path.GetExtension(introductionVideo.FileName).ToLower();
                    if (fileExtension != ".mp4")
                        ModelState.AddModelError(string.Empty, "Please select MP4 format video only");
                }
                if (model.Gender != GenderConstants.Male && model.Gender != GenderConstants.Female)
                    ModelState.AddModelError(string.Empty, "Please select valid option for Gender");

                if (ModelState.IsValid)
                {
                    if (profileImage != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + profileImage.FileName;
                        using (Image image = Image.FromStream(profileImage.InputStream))
                        {
                            using (var fullImage = image.GetThumbnailImage(600, 500, null, new System.IntPtr()))
                            using (var thumbNailImage = image.GetThumbnailImage(128, 128, null, new System.IntPtr()))
                            {
                                string profileFullImageFolder = Server.MapPath(ConfigurationManager.AppSettings[WebsiteConstants.ProfileFullImageFolder]);
                                string profileThumbnailImageFolder = Server.MapPath(ConfigurationManager.AppSettings[WebsiteConstants.profileThumbnailImageFolder]);
                                fullImage.Save(profileFullImageFolder + fileName, ImageFormat.Jpeg);
                                thumbNailImage.Save(profileThumbnailImageFolder + fileName, ImageFormat.Jpeg);
                            }
                        }
                        model.ProfileImage = fileName;
                    }
                    else if(string.IsNullOrEmpty(model.ProfileImage))
                    {
                        if (model.Gender == GenderConstants.Male)
                            model.ProfileImage = WebsiteConstants.DefaultProfilePicMale;
                        else
                            model.ProfileImage = WebsiteConstants.DefaultProfilePicFemale;
                    }
                    if (introductionVideo != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + introductionVideo.FileName;
                        introductionVideo.SaveAs(Server.MapPath(ConfigurationManager.AppSettings[WebsiteConstants.IntroductionVideoFolder]) + fileName);
                        model.VideoIntroduction = fileName;
                    }
                   
                    if (userProfileViewModel.CertificationsList.Count > 0)
                    {
                        userProfileViewModel.CertificationsList.RemoveAll(m => m.IsDeleted && m.HasTempCertificationId);
                        model.CertificationDetailXML = new ConvertObjectToXML().ConvertObjectToXml(userProfileViewModel.CertificationsList);
                    }

                    new UserRepository().InsertUpdateUserProfile(model);
                    Session.Remove(SessionNameConstants.CompleteProfileSession);
                    if (!model.UserProfileId.HasValue)
                    {
                        await SignInAsync(userSession, false);
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        TempData[SessionNameConstants.SuccessMessage] = "Profile updated";
                        return RedirectToAction("CompleteProfile");
                    }
                }
                model.CountriesList = GetCountriesList().ToList();
                model.TimeZoneList = GetTimeZoneList().ToList();
            }
            else
                ModelState.AddModelError(string.Empty, "Please login to complete your profile");            
            return View(model);
        }

        //
        // POST: /Account/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, Url.Action("LinkLoginCallback", "Account"), User.Identity.GetUserId());
        }

        //
        // GET: /Account/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            if (result.Succeeded)
            {
                return RedirectToAction("Manage");
            }
            return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
        }

        public ActionResult SaveSelectedCategories()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }

        #region Manage certifications region
        [AllowAnonymous]
        public ActionResult GetCertifications([DataSourceRequest]DataSourceRequest request)
        {
            var userProfileViewModel = (UserProfileViewModel)Session[SessionNameConstants.CompleteProfileSession];
            userProfileViewModel = new UserProfileViewModel();
            userProfileViewModel.CertificationsList = new List<CertificationViewModel>();
            Session[SessionNameConstants.CompleteProfileSession] = userProfileViewModel;
            return Json(userProfileViewModel.CertificationsList.ToDataSourceResult(request));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddCertification([DataSourceRequest] DataSourceRequest request, CertificationViewModel model)
        {
            var userProfileViewModel = (UserProfileViewModel)Session[SessionNameConstants.CompleteProfileSession];

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
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult DeleteCertification([DataSourceRequest] DataSourceRequest request, CertificationViewModel model)
        {
            var userProfileViewModel = (UserProfileViewModel)Session[SessionNameConstants.CompleteProfileSession];
            userProfileViewModel.CertificationsList.Remove(userProfileViewModel.CertificationsList.FirstOrDefault(x => x.CertificationId == x.CertificationId));
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult UpdateCertification([DataSourceRequest] DataSourceRequest request, CertificationViewModel model)
        {
            var userProfileViewModel = (UserProfileViewModel)Session[SessionNameConstants.CompleteProfileSession];
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
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
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

        private ActionResult RedirectToLocal(string returnUrl)
        {
            var FullUrl = Request.Url.AbsolutePath.ToString();


            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else if (returnUrl != null)
            {
                return RedirectToAction("FindJobs", "FindAndApplyJob", new { @text = returnUrl });
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");

            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

        #region Validations
        [AllowAnonymous]
        public JsonResult IsEmailAddressAlreadyExists(RegisterViewModel model)
        {
            return Json(new UserRepository().IsEmailAddressAlreadyExists(model.Email), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult IsUserNameAlreadyExists(RegisterViewModel model)
        {
            return Json(new UserRepository().IsUserNameAlreadyExists(model.UserName), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}