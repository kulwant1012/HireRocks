using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using PS.Data.Entities;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class Reports:Entity
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string ActivityName { get; set; }
        [DataMember]
        public string QspaceName { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public double TimeLogged { get; set; }
        [DataMember]
        public float OriginalEstimate { get; set; }
        [DataMember]
        public float ActualDuration { get; set; }
        [DataMember]
        public string ActivityUserId { get; set; }
    }
}
