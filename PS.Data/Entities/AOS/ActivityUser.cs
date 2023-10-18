using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class ActivityUser : Entity
    {
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string ActivityId { get; set; }
        [DataMember]
        public bool IsActivityViewed { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
