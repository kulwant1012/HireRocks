using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class NotificationsViewModel
    {
        public long? NotificationId { get; set; }
        public string NotificationText { get; set; }
        public bool? IsViewed { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateTime { get; set; }
        public string UserId { get; set; }
        public string NotificationType { get; set; }
        public long? ObjectId { get; set; }

    }
}
