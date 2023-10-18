using PS.HireRocks.Data.Database;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace PS.HireRocks.Data.Repositories
{
    public class ReportRepository
    {
        public DataTable GetWorkerHourlyReportByWorkerIdAndClientId(string WorkerId, DateTime fromdate, long? JobId, string ClientId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("WorkerHourlyReportByWorkerIdAndClientId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@workerid ", WorkerId);
            cmd.Parameters.Add("@date", fromdate);
            cmd.Parameters.Add("@JobId", JobId);
            cmd.Parameters.Add("@ClientId", ClientId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;
        }

        public DataTable GetWorkerWeeklyReportByWorkerIdAndClientId(string workerId, DateTime fromDate, DateTime toDate, long? JobId, string ClientId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("WorkerWeeklyReportByWorkerIdAndClientId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkerId",workerId);
            cmd.Parameters.Add("@FromDate",fromDate);
            cmd.Parameters.Add("@ToDate",toDate);
            cmd.Parameters.Add("@JobId",JobId);
            cmd.Parameters.Add("@ClientId",ClientId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;
        }

        public DataTable GetWorkerYearlyReportByWorkerIdAndClientId(string WorkerId, DateTime fromdate, long? JobId, string ClientId)
        {
            var year = fromdate.Year;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("WorkerYearlyReportByWorkerIdAndClientId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkerId ", WorkerId);
            cmd.Parameters.Add("@Year", year);
            cmd.Parameters.Add("@JobId", JobId);
            cmd.Parameters.Add("@ClientId", ClientId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;
        }

        public DataTable GetWorkerHourlyReportByWorkerId(string WorkerId, DateTime fromdate,long? JobId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("WorkerHourlyReportByWorkerId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@workerid ", WorkerId);
            cmd.Parameters.Add("@date", fromdate);
           // cmd.Parameters.Add("@JobId", JobId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;
        }

        public DataTable GetWorkerWeeklyReportByWorkerId(string workerId, DateTime fromDate, DateTime toDate,long? JobId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("WorkerWeeklyReportByWorkerId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkerId", workerId);
            cmd.Parameters.Add("@FromDate", fromDate);
            cmd.Parameters.Add("@ToDate", toDate);
            cmd.Parameters.Add("@JobId", JobId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;
        }

        public DataTable GetWorkerYearlyReportByWorkerId(string WorkerId, DateTime fromdate,long? JobId)
        {
            var year = fromdate.Year;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("WorkerYearlyReportByWorkerId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WorkerId ", WorkerId);
            cmd.Parameters.Add("@Year", year);
            cmd.Parameters.Add("@JobId", JobId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;
        }

        public IEnumerable<GetWorkerViewModel> GetClientTeam(string clientId, long? jobId, bool? showActiveWorkers)
        {
            using (var entities = new Entities())
            {
                return entities.GetClientTeam(clientId, jobId, showActiveWorkers).ToList().Select(x => new GetWorkerViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Country = x.Country1,
                    ProfileImage = x.ProfilePic,
                    WorkerId = x.Id,
                    HourlyRate = x.UserHourlyRate,
                    Rating = x.UserRating
                });
            }
        }

        public IEnumerable<SelectListItem> GetClientJobList(string clientId)
        {
            using (var entities = new Entities())
            {
                return entities.GetJobListForMessageScreen(clientId).ToList().Select(x => new SelectListItem { Text = x.JobTitle, Value = x.JobId.ToString() });
            }
        }

        public IEnumerable<SelectListItem> GetWorkerJobList(string Workerid)
        {
            using (var entities = new Entities())
            {
                return entities.GetWorkerJobsByWorkerId(Workerid).ToList().Select(x => new SelectListItem { Text = x.JobTitle, Value = x.JobId.ToString() });
            }
        }

        public DataTable GetClientSummaryReport(string ClientId, DateTime fromdate,DateTime todate)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("WorkSummaryOfClientByClientId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClientId ", ClientId);
            cmd.Parameters.Add("@StartDate", fromdate);
            cmd.Parameters.Add("@EndDate", todate);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;
        }

        public DataTable GetClientTimeLogReport(string ClientId, DateTime fromdate, DateTime todate)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GetTimeLogByClientId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClientId ", ClientId);
            cmd.Parameters.Add("@StartDate", fromdate);
            cmd.Parameters.Add("@EndDate", todate);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            return datatable;
        }

    }
}