using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities
{
    [DataContract]
    public class Company : Entity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Website { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string ExtensionData { get; set; }

        [DataMember]
        public string[] BrandIds { get; set; }
    }

    [DataContract]
    public class Brand : Entity
    {
        [DataMember]
        public string Name { get; set; }
    }
}
