using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AVS
{
    [DataContract]
    public class MatchedKeyword : Entity
    {
        [DataMember]
        public string KeywordDictionaryId { get; set; }
        [DataMember]
        public string CapturedData { get; set; }
        [DataMember]
        public DateTime BeginTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }
    }
}
