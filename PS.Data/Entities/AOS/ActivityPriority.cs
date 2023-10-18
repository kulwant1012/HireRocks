using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class ActivityPriority:Entity
    {
        [DataMember]
        public string PriorityName { get; set; }
    }
}
