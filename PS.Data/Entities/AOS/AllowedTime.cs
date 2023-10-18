using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class AllowedTime : Entity
    {
        [DataMember]
        public string TimeFrom { get; set; }
        [DataMember]
        public string TimeTo { get; set; }
        //[DataMember]
        //public List<int> Months { get; set; }
        //[DataMember]
        //public List<int> Days { get; set; }
        //[DataMember]
        //public List<int> Hours { get; set; }
        //[DataMember]
        //public List<int> Minutes { get; set; }
        //[DataMember]
        //public List<int> Seconds { get; set; }
    }
}
