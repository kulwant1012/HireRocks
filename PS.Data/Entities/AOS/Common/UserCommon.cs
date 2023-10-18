using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.AOS.Common
{
    [DataContract]
    public class UserCommon : Entity
    {
        [DataMember]
        public Boolean IsActive { get; set; }
        [DataMember]
        public Boolean IsLocked { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public Boolean UseWindowsAuthentication { get; set; }
        [DataMember]
        public string WindowsId { get; set; }
        [DataMember]
        public string LoginId { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int[] SecurityRoles { get; set; }
        [DataMember]
        public string RavenUserId { get; set; }
        [DataMember]
        public string OTNUserId { get; set; }
    }
}
