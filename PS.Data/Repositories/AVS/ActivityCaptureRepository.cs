using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PS.Data.Entities.AVS;
using Raven.Abstractions.Data;
using Raven.Client.Linq;
using PS.Data.Entities.AOS;

namespace PS.Data.Repositories.AVS
{
    public class ActivityCaptureRepository : Repository<ActivityCapture>, IActivityCaptureRepository
    {
        public void UpdateOTNSyncStatus(List<ActivityCapture> capturesList)
        {
            using (var session = DocumentStore.OpenSession())
            {
                foreach (var item in capturesList)
                {
                    session.Store(item);
                }
                session.SaveChanges();
            }
        }

        public void UpdateVerificationStatus(string entityId, VerificationStatus verificationStatus,bool isCaptureAcceptanceChanged)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var info = session.Query<ActivityCapture>().FirstOrDefault(x => x.Id == entityId);
                info.VerificationStatus = verificationStatus;
                session.Store(info);


                session.SaveChanges();
            }
        }

        public ICollection<ActivityCapture> GetActivityCapturesByActivityId(string activityId)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var activityUsers = session.Query<ActivityUser>().Where(x=>x.ActivityId==activityId);
                var captures= session.Query<ActivityCapture>().Where(x=>x.ActivityUserID.In(activityUsers.Select(y=>y.Id)));
                return captures.ToList();
            }
        }
    }
}
