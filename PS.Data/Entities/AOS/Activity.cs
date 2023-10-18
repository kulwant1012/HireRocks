using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class Activity : Entity
    {
        [DataMember]
        public string QSpaceID { get; set; }
        [DataMember]
        public string ActivityName { get; set; }
        [DataMember]
        public string ActivityStatusId { get; set; }
        [DataMember]
        public int OTNActivityId { get; set; }

        [DataMember]
        public Attachment[] Attachments { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}
