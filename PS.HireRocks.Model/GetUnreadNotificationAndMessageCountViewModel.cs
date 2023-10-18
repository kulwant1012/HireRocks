using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class GetUnreadNotificationAndMessageCountViewModel
    {
        public int? UnreadMessagesCount { get; set; }
        public int? UnreadNotificationsCount { get; set; }
    }
}
