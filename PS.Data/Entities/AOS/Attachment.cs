using System.Runtime.Serialization;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class Attachment : Entity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Url { get; set; }
    }
}
