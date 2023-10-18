using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class NotificationClients:Entity
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string ConnectionId { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string GroupName { get; set; }
    }
}
