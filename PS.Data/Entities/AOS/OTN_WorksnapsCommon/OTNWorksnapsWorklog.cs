using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.AOS.OTN_WorksnapsCommon
{
    [DataContract]
    public class OTNWorksnapsWorklog : Entity
    {
        [DataMember]
        public string[] WorkSnapsId { get; set; }
        [DataMember]
        public string OtnId { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string Duration { get; set; }
        [DataMember]
        public string TimeUnitId { get; set; }
        [DataMember]
        public string ItemId { get; set; }
        [DataMember]
        public string ItemType { get; set; }
        [DataMember]
        public string WorkLogTypeId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string DateTime { get; set; }
        [DataMember]
        public string RemainingTimeDuration { get; set; }
        [DataMember]
        public string WorkSnapsProjectId { get; set; }
        [DataMember]
        public string WorkSnapsTaskId { get; set; }
        [DataMember]
        public string WorkSnapsUserId { get; set; }
        [DataMember]
        public string WorkSnapsHours { get; set; }
        [DataMember]
        public string WorksnapsCoomment { get; set; }
        [DataMember]
        public string DateWorked { get; set; }
    }
}
