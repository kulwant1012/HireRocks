using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.AOS.OTN_WorksnapsCommon
{
    [DataContract]
    public class OTNWorksnapsQSpace : Entity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime DueDate { get; set; }
        [DataMember]
        public string OtnId { get; set; }
        [DataMember]
        public string WorkSnapsId { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public OTNWorksnapsQSpace()
        {
            StartDate = DateTime.Now;
            DueDate = DateTime.Now;
        }
    }
}
