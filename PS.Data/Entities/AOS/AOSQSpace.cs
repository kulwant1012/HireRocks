using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class AOSQSpace : Entity
    {
        [DataMember]
        public string QSpaceType { get; set; }
        [DataMember]
        public string QSpaceName { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime DueDate { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool IsActive { get; set; }


        [DataMember]
        public int OTNQSpaceId { get; set; }
    }
}
