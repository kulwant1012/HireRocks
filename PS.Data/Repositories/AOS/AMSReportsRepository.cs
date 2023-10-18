using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PS.Data.Entities.AOS;
using Raven.Client.Linq;
using PS.Data.Entities.AVS;

namespace PS.Data.Repositories.AOS
{
    public class AMSReportsRepository : Repository<Reports>
    {
        public ICollection<Reports> GetReportData(string qSpaceId, string userId, string activityId, DateTime? fromDate, DateTime? toDate)
        {
            using (var session = DocumentStore.OpenSession())
            {
                try
                {
                    var reportData = (from qSpace in session.Query<AOSQSpace>().ToList()
                                      join activity in session.Query<Activity>().ToList()
                                      on qSpace.Id equals activity.QSpaceID
                                      join activityComposition in session.Query<ActivityComposition>().ToList()
                                      on activity.Id equals activityComposition.ActivityID
                                      join activityUser in session.Query<ActivityUser>().ToList()
                                      on activity.Id equals activityUser.ActivityId
                                      join user in session.Query<User>().ToList()
                                      on activityUser.UserId equals user.Id
                                      join activityCapture in session.Query<ActivityCapture>().Where(x => x.CaptureDateTime.Date >= fromDate.Value.Date && x.CaptureDateTime.Date <= toDate.Value.Date && x.VerificationStatus.IsAccepted == true && x.VerificationStatus.IsValid == true).ToList()
                                      on activityUser.Id equals activityCapture.ActivityUserID
                                      where (qSpace.Id == qSpaceId || string.IsNullOrEmpty(qSpaceId)) && (user.Id == userId || string.IsNullOrEmpty(userId))
                                      select new Reports
                                      {
                                          ActivityName = activity.ActivityName,
                                          Date = activityCapture.CaptureDateTime,
                                          OriginalEstimate = activityComposition.MaximumDuration,
                                          QspaceName = qSpace.QSpaceName,
                                          ActivityUserId = activityUser.Id,
                                          TimeLogged = activityCapture.TimeBurned.TotalSeconds,
                                          UserName = user.FirstName
                                      }).GroupBy(x => new { x.Date.Date, x.ActivityUserId }).AsParallel();

                    var report = from data in reportData
                                 select new Reports
                                 {
                                     ActivityUserId = data.FirstOrDefault().ActivityUserId,
                                     ActivityName = data.FirstOrDefault().ActivityName,
                                     Date = data.FirstOrDefault().Date,
                                     OriginalEstimate = data.FirstOrDefault().OriginalEstimate,
                                     QspaceName = data.FirstOrDefault().QspaceName,
                                     TimeLogged = data.Sum(x => x.TimeLogged)/3600,
                                     UserName = data.FirstOrDefault().UserName
                                 };

                    return report.ToList();
                }

                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
