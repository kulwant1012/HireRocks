using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PS.HireRocks.Model
{
    public class MessageViewModel
    {
        public long? MessageId { get; set; }
        public string MessageText { get; set; }
        public string DateTime { get; set; }
        public string MessageBorder { get; set; }
        public string MessageFromUserId { get; set; }
        public string MessageToUserId { get; set; }
        public long? JobId { get; set; }
        public bool IsMessageSent { get; set; }
        public string MessageTemplateClassName { get; set; }
        public string MessageUserName { get; set; }
    }
}
