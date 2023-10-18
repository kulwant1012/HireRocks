using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class ActivityStatus : Entity
    {
        [DataMember]
        public string StatusName { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
