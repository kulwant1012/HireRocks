using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.AOS.OTN_WorksnapsCommon
{
    [DataContract]
    public class LastSyncDate : Entity
    {
        [DataMember]
        public DateTime LastSyncTime { get; set; }
        public LastSyncDate(DateTime? lastSyncDateTime)
        {
            if (lastSyncDateTime.HasValue)
                LastSyncTime = lastSyncDateTime.Value;
        }
    }
}
