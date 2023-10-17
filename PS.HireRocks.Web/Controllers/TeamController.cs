using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.Web.Helpers;
using PS.HireRocks.Web.Models;

namespace PS.HireRocks.Web.Controllers
{
    public class TeamController : BaseController
    {
        public ActionResult MyTeam()
        {
            return View();
        }

        public async Task<ActionResult> GetTeamsGridData([DataSourceRequest] DataSourceRequest request,long? jobId, bool? showActiveWorkers)
        {
            IEnumerable<GetWorkerViewModel> teamList = null;
            var user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            if (user != null)
                teamList = await ExecuteFunction(() => new WorkerRepository().GetClientTeam(user.Id,jobId,showActiveWorkers));
            return Json(teamList.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetJobList()
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json(await ExecuteFunction(() => new MessageRepository().GetClientJobList(user.Id)), JsonRequestBehavior.AllowGet);
        }
    }
}