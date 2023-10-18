using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities
{
    [DataContract]
    public class QSpaceRole : QSpace
    {
        [DataMember]
        public bool CanCreateChild { get; set; }

        [DataMember]
        public bool CanDeleteChild { get; set; }

        [DataMember]
        public bool Name { get; set; }
    }   
}
