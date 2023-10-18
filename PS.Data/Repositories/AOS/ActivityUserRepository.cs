using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PS.Data.Entities.AOS;
using Raven.Client.Linq;

namespace PS.Data.Repositories.AOS
{
    public class ActivityUserRepository:Repository<ActivityUser>
    {
        public void UpdateActivityViewStatus(string[] activityIds)
        {
            using (var session = DocumentStore.OpenSession())
            {
                foreach (var activityUser in session.Query<ActivityUser>().Where(x=>x.ActivityId.In(activityIds)))
                {
                    activityUser.IsActivityViewed = true;
                }
                session.SaveChanges();
            }
        }

        public ActivityUser AddOrUpdateActivityUser(ActivityUser activityUser, bool isAssignedToChanged)
        {
            using (var session = DocumentStore.OpenSession())
            {
                if (isAssignedToChanged)
                {
                    session.Query<ActivityUser>().FirstOrDefault(x => x.Id == activityUser.Id).IsActive = false;
                    activityUser.Id = Guid.NewGuid().ToString();
                    activityUser.IsActive = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(activityUser.Id))
                        activityUser.Id = Guid.NewGuid().ToString();
                    activityUser.IsActive = true;                   
                }
                session.Store(activityUser);
                session.SaveChanges();
                return activityUser;
            }
        }
    }
}
