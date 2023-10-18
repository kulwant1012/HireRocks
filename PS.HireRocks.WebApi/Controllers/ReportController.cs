using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.Net;

namespace PS.HireRocks.WebApi.Controllers
{
    [RoutePrefix("api/Report")]
    public class ReportController : BaseController
    {
        public ReportController()
        : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public ReportController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // AccessTokenFormat = accessTokenFormat;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }


        [HttpGet]
        [Authorize]
        [Route("GetWorkerReportByWorkerId")]
        public IHttpActionResult GetWorkerReportByWorkerId(string rangeType, DateTime fromdate, DateTime todate,bool type,long? JobId)
        {
            try
            {
                var user = User.Identity.GetUserId();
                string WorkerId = user;
                ReportDocument crystalReport = new ReportDocument();
                DataTable result = new DataTable();
                var DocFormat = Request.GetQueryNameValuePairs().FirstOrDefault(q => q.Key == "DocFormat").Value;

                if (rangeType == "Day")
                {
                    result = new ReportRepository().GetWorkerHourlyReportByWorkerId(WorkerId, fromdate, JobId);
                    crystalReport.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/Report/WorkerHourlyReportByWorkerId.rpt"));
                    crystalReport.SetDataSource(result);
                    crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerHourlyReport");
                }
                else if (rangeType == "Week" || rangeType == "Month")
                {
                    result = new ReportRepository().GetWorkerWeeklyReportByWorkerId(WorkerId, fromdate, todate, JobId);
                    crystalReport.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/Report/WorkerWeeklyReportByWorkerId.rpt"));
                    crystalReport.SetDataSource(result);
                    crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerWeekReport");
                }
                else if (rangeType == "Year")
                {
                    result = new ReportRepository().GetWorkerYearlyReportByWorkerId(WorkerId, fromdate, JobId);
                    crystalReport.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/Report/WorkerYearlyReportByWorkerId.rpt"));
                    crystalReport.SetDataSource(result);
                    crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerYearReport");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("GetWorkerReportByWorkerIdAndClientId")]
        public IHttpActionResult GetWorkerReportByWorkerIdAndClientId(String WorkerId, string rangeType, DateTime fromdate, DateTime todate, bool type, long? JobId)
        {
            try
            {
                var user = User.Identity.GetUserId();
                string ClientId = user;
                ReportDocument crystalReport = new ReportDocument();
                var DocFormat = HttpContext.Current.Request.QueryString["DocFormat"];
                DataTable result = new DataTable();

                if (rangeType == "Day")
                {
                    result = new ReportRepository().GetWorkerHourlyReportByWorkerIdAndClientId(WorkerId, fromdate, JobId, ClientId);
                    crystalReport.Load(HttpContext.Current.Server.MapPath("~/Report/WorkerHourlyReportByWorkerId.rpt"));
                    crystalReport.SetDataSource(result);
                    crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerHourlyReport");
                }
                else if (rangeType == "Week" || rangeType == "Month")
                {
                    result = new ReportRepository().GetWorkerWeeklyReportByWorkerIdAndClientId(WorkerId, fromdate, todate, JobId, ClientId);
                    crystalReport.Load(HttpContext.Current.Server.MapPath("~/Report/WorkerWeeklyReportByWorkerId.rpt"));
                    crystalReport.SetDataSource(result);
                    crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerWeekReport");
                }
                else if (rangeType == "Year")
                {
                    result = new ReportRepository().GetWorkerYearlyReportByWorkerIdAndClientId(WorkerId, fromdate, JobId, ClientId);
                    crystalReport.Load(HttpContext.Current.Server.MapPath("~/Report/WorkerYearlyReportByWorkerId.rpt"));
                    crystalReport.SetDataSource(result);
                    crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerYearReport");
                }

                return Ok(); // You can return an appropriate response here
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("GetTeamsGridData")]
        public async Task<IHttpActionResult> GetTeamsGridData([FromUri] long? jobId, bool? showActiveWorkers)
        {
            IEnumerable<GetWorkerViewModel> teamList = null;
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
                teamList = await ExecuteFunction(() => new ReportRepository().GetClientTeam(User.Identity.GetUserId(), jobId, showActiveWorkers));
            return Ok(teamList);
        }

        [HttpGet]
        [Authorize]
        [Route("GetJobList")]
        public async Task<HttpResponseMessage> GetJobList()
        {
            var jobList = await ExecuteFunction(() => new ReportRepository().GetClientJobList(User.Identity.GetUserId()));
            return Request.CreateResponse(HttpStatusCode.OK, jobList);
            
        }
        [HttpGet]
        [Authorize]
        [Route("GetWorkerJobList")]
        public async Task<HttpResponseMessage> GetWorkerJobList()
        {
;
            var jobs = await ExecuteFunction(() => new ReportRepository().GetWorkerJobList(User.Identity.GetUserId()));
            return Request.CreateResponse(HttpStatusCode.OK, jobs);
        }

        [HttpGet]
        [Authorize]
        [Route("GetClientReport")]
        public HttpResponseMessage GetClientReport(DateTime fromdate,DateTime todate,bool type,string reporttype)
        {
            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());
            string ClientId = User.Identity.GetUserId();
            ReportDocument crystalReport = new ReportDocument();
            var DocFormat = HttpContext.Current.Request.QueryString["DocFormat"];
            DataTable result = new DataTable();
            if (reporttype == "Summary")
            {
                result = new ReportRepository().GetClientSummaryReport(ClientId, fromdate, todate);
                crystalReport.Load(HttpContext.Current.Server.MapPath("~/Report/ClientWorkSummeryReport.rpt"));
                crystalReport.SetDataSource(result);
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerHourlyReport");
            }
            else 
            {
                result = new ReportRepository().GetClientTimeLogReport(ClientId, fromdate, todate);
                crystalReport.Load(HttpContext.Current.Server.MapPath("~/Report/ClientWorkTimeLog.rpt"));
                crystalReport.SetDataSource(result);
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerWeekReport");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Report generated successfully.");
        }
    }
}