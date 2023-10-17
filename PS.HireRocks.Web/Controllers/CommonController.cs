using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.Web.Helpers;

namespace PS.HireRocks.Web.Controllers
{
    public class CommonController : BaseController
    {
        public async Task<ActionResult> GetContractEndReasons()
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json(await ExecuteFunction(() => new ContractRepository().GetContractEndReasonsByRoleId(user.Roles.FirstOrDefault().RoleId)), JsonRequestBehavior.AllowGet);
        }
	}
}