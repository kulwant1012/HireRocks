using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class KeywordDictionary : Entity
    {
        [DataMember]
        public string DictionaryName { get; set; }
        [DataMember]
        public string[] Keywords { get; set; }
    }
}
