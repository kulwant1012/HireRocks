using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.AOS.Common
{
    [DataContract]
    public class QSpaceCommon : Entity
    {
        [DataMember]
        public string QSpaceName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime DueDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string ParentQSpaceId { get; set; }
        [DataMember]
        public string QSpaceType { get; set; }
        [DataMember]
        public string OtnQSpaceId { get; set; }
        [DataMember]
        public string AOSQSpaceId { get; set; }
    }
}
