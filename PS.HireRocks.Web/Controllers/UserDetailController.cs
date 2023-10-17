using Kendo.Mvc.UI;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using PS.HireRocks.Web.Models;
using PS.HireRocks.Web.Helpers;

namespace PS.HireRocks.Web.Controllers
{
    public class UserDetailController : BaseController
    {

        public async Task<ActionResult> WorkerDetail(string workerId)
        {
            GetUserByIdViewModel getUserByIdViewModel = new GetUserByIdViewModel();
            getUserByIdViewModel = await ExecuteFunction(() => new UserDetailRepository().GetWorkerInfoByWorkerId(workerId));
            return View(getUserByIdViewModel);
        }
        [AllowAnonymous]
        public async Task<ActionResult> GetWorkerJobs([DataSourceRequest] DataSourceRequest request, string workerId)
        {
            IEnumerable<WorkerJobsViewModel> WorkerJobs = new List<WorkerJobsViewModel>();
            WorkerJobs = await ExecuteFunction(() => new UserDetailRepository().GetWorkerJobs(workerId));
            return Json(WorkerJobs.ToDataSourceResult(request));
        }

	}
}