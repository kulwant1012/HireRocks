using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities
{
    [DataContract]
    public class Experience : QSpace
    {
        [DataMember]
        public string Name { get; set; }       
    }   
}
