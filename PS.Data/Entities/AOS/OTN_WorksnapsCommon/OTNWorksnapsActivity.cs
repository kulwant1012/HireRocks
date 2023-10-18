using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.AOS.OTN_WorksnapsCommon
{
    [DataContract]
    public class OTNWorksnapsActivity : Entity
    {
        [DataMember]
        public string OtnId { get; set; }
        [DataMember]
        public string WorksnapsId { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string project { get; set; }
        [DataMember]
        public string workflow_step { get; set; }
        [DataMember]
        public string release { get; set; }
        [DataMember]
        public DateTime start_date { get; set; }
        [DataMember]
        public DateTime due_date { get; set; }
        [DataMember]
        public DateTime completion_date { get; set; }
        [DataMember]
        public string priority { get; set; }
        [DataMember]
        public string assigned_to { get; set; }
        [DataMember]
        public string reported_by { get; set; }
        [DataMember]
        public float estimated_duration { get; set; }
        [DataMember]
        public float actual_duration { get; set; }
        [DataMember]
        public float remaining_duration { get; set; }
        [DataMember]
        public Boolean publicly_viewable { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string WSprojectId { get; set; }
        [DataMember]
        public string WSUserId { get; set; }

        public OTNWorksnapsActivity()
        {
            start_date = DateTime.Now;
            due_date = DateTime.Now;
            completion_date = DateTime.Now;
        }
    }
}
