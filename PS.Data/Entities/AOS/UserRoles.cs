using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class UserRoles:Entity
    {
        [DataMember]
        public string RoleName { get; set; }
    }
}
