using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.Web.Helpers;
using System.Linq;


namespace PS.HireRocks.Web.Controllers
{
    public class CaptureController : BaseController
    {
        public ActionResult Captures(long? contractId)
        {
            return View();
        }

        public ActionResult ClientCapturesReview(long jobId)
        {
            return View(new CaptureRepository().GetCaptureScreenData(jobId));
        }

        public async Task<ActionResult> GetJobCaptues([DataSourceRequest] DataSourceRequest request, long contractId, DateTime fromDate, DateTime toDate)
        {
            fromDate = DateTime.SpecifyKind(fromDate, DateTimeKind.Utc).ToUniversalTime();
            toDate = DateTime.SpecifyKind(toDate.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc).ToUniversalTime();
            var captureList = await ExecuteFunction(() => new CaptureRepository().GetJobCaptures(contractId, fromDate, toDate));
            foreach(var item in captureList)
            {
                DateTime UTCDate = DateTime.SpecifyKind(item.CaptureDate.Value,DateTimeKind.Utc);
                item.CaptureDate = UTCDate.ToUniversalTime();
            }
            TempData[SessionNameConstants.TotalHoursBurned] = TimeSpan.FromMilliseconds((double)captureList.Where(x => !x.IsRejected.HasValue || !x.IsRejected.Value).Sum(x => x.TimeBurned)).ToString("hh\\:mm");
            return Json(captureList.ToDataSourceResult(request));
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCapture([DataSourceRequest] DataSourceRequest request, string captureIdsToDelete)
        {
            await ExecuteFunction(() => new CaptureRepository().DeleteCapture(captureIdsToDelete));
            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> RejectCapture(string captureIdsToReject, DateTime fromDate, DateTime toDate)
        {
            fromDate = DateTime.SpecifyKind(fromDate, DateTimeKind.Utc).ToUniversalTime();
            toDate = DateTime.SpecifyKind(toDate.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc).ToUniversalTime();  
            await ExecuteFunction(() => new CaptureRepository().RejectCapture(captureIdsToReject, fromDate, toDate));
            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetCapturesForClientReview([DataSourceRequest] DataSourceRequest request, long jobId, string workerId, DateTime fromDate, DateTime toDate, bool? isRejected)
        {
            fromDate = DateTime.SpecifyKind(fromDate, DateTimeKind.Utc).ToUniversalTime();
            toDate = DateTime.SpecifyKind(toDate.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc).ToUniversalTime();    
            var result = await ExecuteFunction(() => new CaptureRepository().GetCapturesForClientReview(jobId, workerId, fromDate, toDate, isRejected));
            foreach(var item in result)
            {
                DateTime UTCDate = DateTime.SpecifyKind(item.CaptureDate.Value, DateTimeKind.Utc);
                item.CaptureDate = UTCDate.ToUniversalTime();
            }
            TempData[SessionNameConstants.TotalHoursBurned] = TimeSpan.FromMilliseconds((double)result.Where(x => !x.IsRejected.HasValue || !x.IsRejected.Value).Sum(x => x.TimeBurned)).ToString("hh\\:mm");
            return Json(result.ToDataSourceResult(request));
        }

        public ActionResult GetWorkerJobs()
        {
            var loggedInUser = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json(new JobRepository().GetJobsByWorkerId(loggedInUser.Id, null), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTotalTimeBurned()
        {
            TempData.Keep();
            return Json(new { TotalHoursBurned = TempData[SessionNameConstants.TotalHoursBurned] }, JsonRequestBehavior.AllowGet);
        }
    }
}