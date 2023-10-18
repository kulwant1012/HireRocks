using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PS.HireRocks.WebApi.Helpers;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace PS.HireRocks.WebApi.Controllers
{
    [RoutePrefix("api/Company")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CompanyController : BaseController
    {

        public CompanyController()
        : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public CompanyController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        //
        // GET: /Company/
      

        [HttpPost]
        [Authorize]
        [Route("SendInvitationToUser")]
        public async Task<object> SendInvitationToUser(InviteUserViewModel InviteUserViewModel)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            string emailBody = string.Format("Hello " + user.FirstName + " " + user.LastName + ", <br/>"
                       + "If you not have Account Click Here<br/>"
                       + ConfigurationManager.AppSettings["ServerAddress"] + "Account/Register</a>"
                       + "If you have Account Click Here<br/>" +
                       ConfigurationManager.AppSettings["ServerAddress"] + "Company/AproveInvitation</a>");
            await new EmailHelper().SendEmailNotification(InviteUserViewModel.Email, "Password reset", emailBody);
            return Request.CreateResponse(HttpStatusCode.OK, "invitation is sent sucessfully.");
        }      
    }
}