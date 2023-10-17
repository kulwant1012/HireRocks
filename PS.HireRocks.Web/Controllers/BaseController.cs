using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.Web.Helpers;
using PS.HireRocks.Web.Models;

namespace PS.HireRocks.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected async Task<T> ExecuteFunction<T>(Func<T> func)
        {
            return await Task.Run(func);
        }

        protected async Task ExecuteFunction(Action act)
        {
            await Task.Run(act);
        }

        public async Task<JsonResult> GetUnreadNotificationAndMessageCount()
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json(await ExecuteFunction(() => new MessageRepository().GetUnreadNotificationAndMessageCount(user.Id)), JsonRequestBehavior.AllowGet);
        }
	}
}