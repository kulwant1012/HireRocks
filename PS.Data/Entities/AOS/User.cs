using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class User : Entity
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public int OTNUserId { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public bool IsLocked { get; set; }
        [DataMember]
        public bool IsOnline { get; set; }
        [DataMember]
        public UserRole[] Roles { get; set; }
    }

    public enum UserRole
    {
        User = 0,
        Manager = 1
    }
}
