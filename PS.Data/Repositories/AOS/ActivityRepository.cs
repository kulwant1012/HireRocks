using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Linq;

using PS.Data.Entities.AOS;
using PS.Data.Entities.AVS;
using Raven.Abstractions.Commands;

namespace PS.Data.Repositories.AOS
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ICollection<Activity> GetActivitiesByOTNActivityIds(int[] otnActivityIds)
        {
            using (var session = DocumentStore.OpenSession())
            {
                return session.Query<Activity>().Where(x => x.OTNActivityId.In<int>(otnActivityIds)).ToList();
            }
        }

        public ICollection<Activity> GetActiveActivitiesByQSpaceIdAndActivityId(string qSpaceId, string[] activityIds)
        {
            using (var session = DocumentStore.OpenSession())
            {
                string[] activityStatus = session.Query<ActivityStatus>().Where(x => x.StatusName == "Rejected" || x.StatusName == "Completed").Select(x => x.Id).ToArray();
                return session.Query<Activity>().Where(x => x.QSpaceID == qSpaceId && x.Id.In<string>(activityIds) && !x.ActivityStatusId.In<string>(activityStatus) && !x.IsDeleted).ToList();
            }
        }

        public void DeleteActivityByActivityId(string activityId)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var activityUsers=session.Query<ActivityUser>().Where(x=>x.ActivityId==activityId);
                var isAnyTimeLogedToActivity = session.Query<ActivityCapture>().FirstOrDefault(x => x.ActivityUserID.In(activityUsers.Select(y => y.Id)));
                var activity = session.Query<Activity>().FirstOrDefault(x => x.Id == activityId);
                var activeActivityUser = activityUsers.FirstOrDefault(x=>x.IsActive==true);

                if (isAnyTimeLogedToActivity != null)
                {
                    activity.IsDeleted = true;
                    if (activeActivityUser != null)
                        activeActivityUser.IsActive = false;
                }
                else
                {
                    var activityComposition = session.Query<ActivityComposition>().FirstOrDefault(x => x.ActivityID == activityId);
                    session.Advanced.Defer(new DeleteCommandData { Key = activityComposition.Id });
                    session.Advanced.Defer(new DeleteCommandData { Key = activity.Id });
                    foreach (var item in activityUsers)
                    {
                        session.Advanced.Defer(new DeleteCommandData { Key = item.Id });
                    }
                }

                session.SaveChanges();
            }
        }

        public ICollection<Activity> GetActivitiesByQSpaceAndUserId(string qSpaceId, string userId)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var activityUser = session.Query<ActivityUser>().Customize(x=>x.Include<ActivityUser>(y=>y.ActivityId)).Where(x => x.UserId == userId);
                var test= session.Load<Activity>(activityUser.Select(x=>x.ActivityId)).Where(x=>x.QSpaceID==qSpaceId);
                return session.Load<Activity>(activityUser.Select(x => x.ActivityId));
            }
        }
    }
}
