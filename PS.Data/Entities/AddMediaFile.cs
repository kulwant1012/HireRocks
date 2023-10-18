using PS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities
{
    [DataContract]
    public class AddMediaFile : Entity
    {
        [DataMember]
        public byte[] MediaFile { get; set; }

        [DataMember]
        public string ContentType { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string Result { get; set; }
    }
}
