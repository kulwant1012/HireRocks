using PS.HireRocks.Data.Database;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Data.Repositories
{
    public class NotificationRepository
    {
        public IEnumerable<NotificationsViewModel> GetNotificationsByUserId(string userId)
        {
            using (var entities = new Entities())
            {
                return entities.GetNotificationByUserId(userId).ToList().Select(x => new NotificationsViewModel
                {
                    NotificationId = x.NotificationId,
                    DateTime = x.DateTime,
                    NotificationText = x.NotificationText,
                    IsViewed=x.IsViewed,
                    NotificationType=x.NotificationType,
                    ObjectId=x.ObjectId

                });
            }
        }

        public void DeleteNotification(long notificationId)
        {
            using (var entities = new Entities())
            {
                entities.DeleteNotificationById(notificationId);
            }
        }

        public GetUnreadNotificationAndMessageCountViewModel GetUnreadNotificationsCount(string userId)
        {
            using (var entities = new Entities())
            {
                return entities.GetUnreadNotificationsCount(userId).Select(x => new GetUnreadNotificationAndMessageCountViewModel { UnreadNotificationsCount = x.Value }).FirstOrDefault();
            }
        }

        public void UpdateNotificationViewedStatus(string userId)
        {
            using (var entities = new Entities())
            {
                entities.UpdateNotificationViewedStatus(userId);
            }
        }
    }
}
