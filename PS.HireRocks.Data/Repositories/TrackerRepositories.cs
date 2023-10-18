using PS.HireRocks.Data.Database;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Data.Repositories
{
    public class TrackerRepositories
    {
        public List<GetJobsForTracker_Result> GetWorkerJobs(string workerId)
        {
            using (var entities = new Entities())
            {
                return entities.GetJobsForTracker(workerId).ToList();                
            }
        }

        public InsertCaptureResultViewModel InsertCapture(CaptureViewModel model)
        {
            using (var entities = new HireRocks.Data.Database.Entities())
            {
                InsertCaptureResultViewModel insertCaptureResultViewModel = new Model.InsertCaptureResultViewModel();
                var result = entities.InsertCapture(model.ContractId, model.KeyCount, model.MouseCount, model.KeyboardCapture, model.MouseCapture, model.ScreenCaptureThumbnailImage, model.ScreenCaptureFullImage, model.CaptureDate, model.TimeBurned).FirstOrDefault();
                if (result != null)
                {
                    insertCaptureResultViewModel.TotalBurnedHours = result.TodayBurnedHours;
                    insertCaptureResultViewModel.WeeklyBurnedHours = result.WeeklyBurnedHours;
                    insertCaptureResultViewModel.TodayBurnedHours = result.TodayBurnedHours;
                    insertCaptureResultViewModel.IsContractOpen = result.IsContractOpen;
                }
                return insertCaptureResultViewModel;
            }
        }
    }
}
