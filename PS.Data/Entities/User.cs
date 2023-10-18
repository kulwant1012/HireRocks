using PS.Data.Entities.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities
{
    [DataContract]
    public class User : QSpace
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public Gender? Gender { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public uint RewardTotal { get; set; }

        [DataMember]
        public uint ScoreTotal { get; set; }

        [DataMember]
        public List<string> Structures { get; set; }

        [DataMember]
        public Wallet Wallet { get; set; }

        [DataMember]
        public List<string> PhotoIds { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Language { get; set; }

        [DataMember]
        public bool IsOnline { get; set; }

        [DataMember]
        public List<string> FriendIds { get; set; } 

        public User()
        {
            Structures = new List<string>();
            FirstName = LastName = Email = Password = string.Empty;
            base.Sector = SectorType.Creation;
            Wallet = new Wallet();
            FriendIds = new List<string>();
        }
    }
}
