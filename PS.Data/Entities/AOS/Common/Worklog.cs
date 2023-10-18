using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Data.Entities.AOS.Common
{
    public class Worklog
    {
        public string[] WorkSnapsId { get; set; }
        public string OtnId { get; set; }
        public string UserId { get; set; }
        public string Duration { get; set; }
        public string TimeUnitId { get; set; }
        public string ItemId { get; set; }
        public string ItemType { get; set; }
        public string WorkLogTypeId { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public string RemainingTimeDuration { get; set; }

        public string WorkSnapsProjectId { get; set; }
        public string WorkSnapsTaskId { get; set; }
        public string WorkSnapsUserId { get; set; }
        public string WorkSnapsHours { get; set; }
        public string WorksnapsCoomment { get; set; }
        public string DateWorked { get; set; }
    }
}
