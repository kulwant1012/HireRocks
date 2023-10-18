using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.AOS.OTN_WorksnapsCommon
{
    [DataContract]
    public class OTNWorksnapsCommonUser : Entity
    {
        [DataMember]
        public Boolean is_active { get; set; }
        [DataMember]
        public Boolean is_locked { get; set; }
        [DataMember]
        public string first_name { get; set; }
        [DataMember]
        public string last_name { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public Boolean use_windows_auth { get; set; }
        [DataMember]
        public string windows_id { get; set; }
        [DataMember]
        public string login_id { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string security_roles { get; set; }
        [DataMember]
        public string login { get; set; }
        [DataMember]
        public Int32 timezone_id { get; set; }
        [DataMember]
        public decimal hourly_rate { get; set; }
        [DataMember]
        public Int32 WorksnapsProjectId { get; set; }
        [DataMember]
        public string WorksnapsRole { get; set; }
        [DataMember]
        public string WorksnapsId { get; set; }
        [DataMember]
        public string OTNId { get; set; }
    }
}
