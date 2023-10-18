using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.WebApi.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PS.HireRocks.WebApi.Controllers
{
    [RoutePrefix("api/Common")]
    public class CommonController : BaseController
    {

        public CommonController()
             : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public CommonController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetContractEndReasons")]
        public async Task<object> GetContractEndReasons()
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var response = await ExecuteFunction(() => new ContractRepository().GetContractEndReasonsByRoleId(user.Roles.FirstOrDefault().RoleId));
            return response;
        }
	}
}