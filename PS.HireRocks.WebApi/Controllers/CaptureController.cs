using System;
using System.Threading.Tasks;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json.Linq;

namespace PS.HireRocks.WebApi.Controllers
{

    [RoutePrefix("api/Capture")]
    public class CaptureController : BaseController
    {
        public CaptureController()
                   : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public CaptureController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        [HttpGet]
        [Route("ClientCapturesReview")]
        [Authorize]
        public object ClientCapturesReview(long jobId)
        {
            var reponse = new CaptureRepository().GetCaptureScreenData(jobId);
            return reponse;
        }

        [HttpGet]
        [Route("GetJobCaptues")]
        [Authorize]
        public async Task<IHttpActionResult> GetJobCaptues([FromUri] long contractId, DateTime fromDate, DateTime toDate)
        {
            fromDate = DateTime.SpecifyKind(fromDate, DateTimeKind.Utc).ToUniversalTime();
            toDate = DateTime.SpecifyKind(toDate.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc).ToUniversalTime();
            var captureList = await ExecuteFunction(() => new CaptureRepository().GetJobCaptures(contractId, fromDate, toDate));
            foreach(var item in captureList)
            {
                DateTime UTCDate = DateTime.SpecifyKind(item.CaptureDate.Value,DateTimeKind.Utc);
                item.CaptureDate = UTCDate.ToUniversalTime();
            }
         
            return Ok(captureList);
        }


        [HttpPost]
        [Route("DeleteCapture")]
        [Authorize]
        public async Task<object> DeleteCapture([FromUri] string captureIdsToDelete)
        {
            await ExecuteFunction(() => new CaptureRepository().DeleteCapture(captureIdsToDelete));
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpPost]
        [Route("RejectCapture")]
        [Authorize]
        public async Task<object> RejectCapture(string captureIdsToReject, DateTime fromDate, DateTime toDate)
        {
            fromDate = DateTime.SpecifyKind(fromDate, DateTimeKind.Utc).ToUniversalTime();
            toDate = DateTime.SpecifyKind(toDate.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc).ToUniversalTime();  
            await ExecuteFunction(() => new CaptureRepository().RejectCapture(captureIdsToReject, fromDate, toDate));
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpGet]
        [Route("GetCapturesForClientReview")]
        [Authorize]
        public async Task<IHttpActionResult> GetCapturesForClientReview([FromUri] long jobId, string workerId, DateTime fromDate, DateTime toDate, bool? isRejected)
        {
            fromDate = DateTime.SpecifyKind(fromDate, DateTimeKind.Utc).ToUniversalTime();
            toDate = DateTime.SpecifyKind(toDate.Date.AddDays(1).AddTicks(-1), DateTimeKind.Utc).ToUniversalTime();    
            var result = await ExecuteFunction(() => new CaptureRepository().GetCapturesForClientReview(jobId, workerId, fromDate, toDate, isRejected));
            foreach(var item in result)
            {
                DateTime UTCDate = DateTime.SpecifyKind(item.CaptureDate.Value, DateTimeKind.Utc);
                item.CaptureDate = UTCDate.ToUniversalTime();
            }
            var GetTotalTimeBurned = TimeSpan.FromMilliseconds((double)result.Where(x => !x.IsRejected.HasValue || !x.IsRejected.Value).Sum(x => x.TimeBurned)).ToString("hh\\:mm");
            var resultg = new JObject();

            resultg.Merge(result);
            resultg.Merge(GetTotalTimeBurned);
            return Ok(resultg);
        }
        [HttpGet]
        [Route("GetWorkerJobs")]
        [Authorize]
        public async Task<object> GetWorkerJobs()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var response = new JobRepository().GetJobsByWorkerId(user.Id, null);
            return Ok(response);
        }     
    }
}