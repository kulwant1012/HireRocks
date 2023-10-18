using PS.HireRocks.Data.Database;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace PS.HireRocks.Data.Repositories
{
    public class CaptureRepository : BaseRepository
    {
        public List<CaptureViewModel> GetJobCaptures(long? contractId, DateTime fromDate, DateTime toDate)
        {
            using (var entities = new Entities())
            {
                return entities.GetJobCapturesByContractId(contractId, fromDate, toDate).ToList().Select(x => new CaptureViewModel
                {
                    CaptureDate = x.CaptureDate,
                    CaptureId = x.CaptureId,
                    ContractId = x.ContractId,
                    KeyboardCapture = x.KeyboardCapture,
                    KeyCount = x.KeyCount,
                    MouseCapture = x.MouseCapture,
                    MouseCount = x.MouseCount,
                    ScreenCaptureFullImage = x.ScreenCaptureFullImage,
                    ScreenCaptureThumbnailImage = x.ScreenCaptureThumbnailImage,
                    TimeBurned = x.TimeBurned,
                    IsRejected = x.IsRejected
                }).ToList();
            }
        }

        public List<CaptureViewModel> GetCapturesForClientReview(long jobId, string workerId, DateTime fromDate, DateTime toDate, bool? isRejected)
        {
            using (var entities = new Entities())
            {
                return entities.GetCapturesForClientReview(workerId, jobId, fromDate, toDate, isRejected).Select(x => new CaptureViewModel
                {
                    CaptureDate = x.CaptureDate,
                    CaptureId = x.CaptureId,
                    ContractId = x.ContractId,
                    KeyboardCapture = x.KeyboardCapture,
                    KeyCount = x.KeyCount,
                    MouseCapture = x.MouseCapture,
                    MouseCount = x.MouseCount,
                    ScreenCaptureFullImage = x.ScreenCaptureFullImage,
                    ScreenCaptureThumbnailImage = x.ScreenCaptureThumbnailImage,
                    TimeBurned = x.TimeBurned,
                    IsRejected = x.IsRejected
                }).ToList();
            }
        }

        public CaptureScreenDataViewModel GetCaptureScreenData(long jobId)
        {
            using (var entities = new Entities())
            {
                CaptureScreenDataViewModel captureScreenDataViewModel = new CaptureScreenDataViewModel();
                var cmd = entities.Database.Connection.CreateCommand();
                cmd.CommandText = "GetCapturesScreenData";
                cmd.CommandType = CommandType.StoredProcedure;
                DbParameter param = cmd.CreateParameter();
                param.ParameterName = "JobId";
                param.DbType = DbType.Int64;
                param.Direction = ParameterDirection.Input;
                param.Value = jobId;
                cmd.Parameters.Add(param);

                entities.Database.Connection.Open();
                var reader = cmd.ExecuteReader();
                captureScreenDataViewModel.WorkersList = ((IObjectContextAdapter)entities).ObjectContext.Translate<ApplicationUser>(reader).ToList().Select(x => new SelectListItem { Value = x.Id, Text = string.Format("{0} {1}", x.FirstName, x.LastName) });
                reader.NextResult();
                captureScreenDataViewModel.JobTitle = ((IObjectContextAdapter)entities).ObjectContext.Translate<CaptureScreenDataViewModel>(reader).FirstOrDefault().JobTitle;

                return captureScreenDataViewModel;
            }
        }

        public void DeleteCapture(string captureIdsToDelete)
        {
            using (var entities = new Entities())
            {
                entities.DeleteCapture(captureIdsToDelete);
            }
        }

        public void RejectCapture(string captureIdsToReject, DateTime fromDate, DateTime toDate)
        {
            using (var entities = new Entities())
            {
                entities.RejectCapture(captureIdsToReject, fromDate, toDate);
            }
        }
    }

}
