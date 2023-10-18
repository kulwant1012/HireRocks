
using System.Runtime.Serialization;
using PS.Data.Interfaces;

namespace PS.Data.Entities
{
    [DataContract]
    public class Entity : IEntity
    {
        [DataMember]
        public string Id { get; set; }
    }
}
