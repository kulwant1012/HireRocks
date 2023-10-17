using PS.HireRocks.Model;
using PS.HireRocks.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PS.HireRocks.Web.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/
        public ActionResult InviteUser()
        {
            return View();
        }

        public async Task<ActionResult> SendInvitationToUser(InviteUserViewModel InviteUserViewModel)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            string emailBody = string.Format("Hello " + user.FirstName + " " + user.LastName + ", <br/>"
                       + "If you not have Account Click Here<br/>"
                       + ConfigurationManager.AppSettings["ServerAddress"] + "Account/Register</a>"
                       + "If you have Account Click Here<br/>" +
                       ConfigurationManager.AppSettings["ServerAddress"] + "Company/AproveInvitation</a>");
            await new EmailHelper().SendEmailNotification(InviteUserViewModel.Email, "Password reset", emailBody);
            return View();
        }

        public ActionResult AproveInvitation()
        {
            return View();
        }
    }
}