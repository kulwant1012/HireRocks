using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PS.HireRocks.WebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/AuthenticateUser")]
    public class AuthenticateUserController : BaseController
    {
        public AuthenticateUserController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public AuthenticateUserController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            AccessTokenFormat = AccessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }


        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("AuthenticateUser")]
        [HttpPost]
        public HttpResponseMessage GetAuthenticateUser(LoginViewModel model)
        {
            try
            {
                var user = UserManager.Find(model.UserName, model.Password);
                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, Result<ApplicationUser>.Error("Email or password is not correct"));
                if (!user.IsEmailVerified)
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, Result<ApplicationUser>.Error("Email not verified yet"));
                return Request.CreateResponse(HttpStatusCode.OK, Result<ApplicationUser>.Success(user));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Result<ApplicationUser>.Error(ex.ToString()));
            }
        }
    }
}
