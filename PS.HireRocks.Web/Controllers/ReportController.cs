using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PS.HireRocks.Data.Repositories;
using PS.HireRocks.Model;
using PS.HireRocks.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PS.HireRocks.Web.Controllers
{
    public class ReportController : BaseController
    {
        public ActionResult Report()
        {
            return View();
        }

        public ActionResult WorkerReport()
        {
            return View();
        }

        public void GetWorkerReportByWorkerId(string rangeType, DateTime fromdate, DateTime todate,bool type,long? JobId)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
                string  WorkerId = user.Id;  
            ReportDocument crystalReport = new ReportDocument();
            var DocFormat = Request.QueryString["DocFormat"];
            DataTable result = new DataTable();
            if (rangeType == "Day")
            {
                result = new ReportRepository().GetWorkerHourlyReportByWorkerId(WorkerId, fromdate,JobId);
                crystalReport.Load(Server.MapPath("~/Report/WorkerHourlyReportByWorkerId.rpt"));
                crystalReport.SetDataSource(result);
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerHourlyReport");
            }
            else if (rangeType == "Week" || rangeType == "Month")
            {
                result = new ReportRepository().GetWorkerWeeklyReportByWorkerId(WorkerId, fromdate, todate,JobId);
                crystalReport.Load(Server.MapPath("~/Report/WorkerWeeklyReportByWorkerId.rpt"));
                crystalReport.SetDataSource(result);
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerWeekReport");
            }
            else if (rangeType == "Year")
            {
                result = new ReportRepository().GetWorkerYearlyReportByWorkerId(WorkerId, fromdate,JobId);
                crystalReport.Load(Server.MapPath("~/Report/WorkerYearlyReportByWorkerId.rpt"));
                crystalReport.SetDataSource(result);
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerWeekReport");
            }

        }

        public void GetWorkerReportByWorkerIdAndClientId(String WorkerId, string rangeType, DateTime fromdate, DateTime todate, bool type, long? JobId)
        {          
                ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
                string  ClientId = user.Id;  
            ReportDocument crystalReport = new ReportDocument();
            var DocFormat = Request.QueryString["DocFormat"];
            DataTable result = new DataTable();
            if (rangeType == "Day")
            {
                result = new ReportRepository().GetWorkerHourlyReportByWorkerIdAndClientId(WorkerId, fromdate, JobId, ClientId);
                crystalReport.Load(Server.MapPath("~/Report/WorkerHourlyReportByWorkerId.rpt"));
                crystalReport.SetDataSource(result);
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerHourlyReport");
            }
            else if (rangeType == "Week" || rangeType == "Month")
            {
                result = new ReportRepository().GetWorkerWeeklyReportByWorkerIdAndClientId(WorkerId, fromdate, todate, JobId, ClientId);
                crystalReport.Load(Server.MapPath("~/Report/WorkerWeeklyReportByWorkerId.rpt"));
                crystalReport.SetDataSource(result);
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerWeekReport");
            }
            else if (rangeType == "Year")
            {
                result = new ReportRepository().GetWorkerYearlyReportByWorkerIdAndClientId(WorkerId, fromdate, JobId, ClientId);
                crystalReport.Load(Server.MapPath("~/Report/WorkerYearlyReportByWorkerId.rpt"));
                crystalReport.SetDataSource(result);
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerWeekReport");
            }

        }

        public async Task<ActionResult> GetTeamsGridData([DataSourceRequest] DataSourceRequest request, long? jobId, bool? showActiveWorkers)
        {
            IEnumerable<GetWorkerViewModel> teamList = null;
            var user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            if (user != null)
                teamList = await ExecuteFunction(() => new ReportRepository().GetClientTeam(user.Id, jobId, showActiveWorkers));
            return Json(teamList.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetJobList()
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json(await ExecuteFunction(() => new ReportRepository().GetClientJobList(user.Id)), JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> GetWorkerJobList()
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            return Json(await ExecuteFunction(() => new ReportRepository().GetWorkerJobList(user.Id)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClientReport()
        {
            return View();
        }

        public void GetClientReport(DateTime fromdate,DateTime todate,bool type,string reporttype)
        {
            ApplicationUser user = (ApplicationUser)Session[SessionNameConstants.LogedInUserSession];
            string ClientId = user.Id;
            ReportDocument crystalReport = new ReportDocument();
            var DocFormat = Request.QueryString["DocFormat"];
            DataTable result = new DataTable();
            if (reporttype == "Summary")
            {
                result = new ReportRepository().GetClientSummaryReport(ClientId, fromdate, todate);
                crystalReport.Load(Server.MapPath("~/Report/ClientWorkSummeryReport.rpt"));
                crystalReport.SetDataSource(result);
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerHourlyReport");
            }
            else 
            {
                result = new ReportRepository().GetClientTimeLogReport(ClientId, fromdate, todate);
                crystalReport.Load(Server.MapPath("~/Report/ClientWorkTimeLog.rpt"));
                crystalReport.SetDataSource(result);
                crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, type, "WorkerWeekReport");
            }
        }
    }
}