using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities
{
    [DataContract]
    public enum Gender
    {
        [EnumMember]
        Male = 0,
        [EnumMember]
        Female = 1
    }

    [DataContract]
    public enum EnergyLevel
    {
        [EnumMember]
        Zero = 0,
        [EnumMember]
        One = 1,
        [EnumMember]
        Two = 2,
        [EnumMember]
        Three = 3,
        [EnumMember]
        Four = 4,
        [EnumMember]
        Five = 5,
        [EnumMember]
        Six = 6,
        [EnumMember]
        Seven = 7,
        [EnumMember]
        Eight = 8,
        [EnumMember]
        Nine = 9,
        [EnumMember]
        Ten = 10,
        [EnumMember]
        Eleven = 11
    }

    [DataContract]
    public enum SectorType
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Structure = 1,
        [EnumMember]
        Creation = 2,
        [EnumMember]
        Collective = 3,
        [EnumMember]
        Resource = 4,
        [EnumMember]
        Information = 5,
        [EnumMember]
        Experience = 6
    }

    [DataContract]
    public enum TaskStatus
    {
        [EnumMember]
        ToDo = 0,
        [EnumMember]
        InProgress = 1,
        [EnumMember]
        Done = 2,
        [EnumMember]
        Canceled = 3
    }

    [DataContract]
    public enum BankAccountType
    {
        [EnumMember]
        Checking = 0,
        [EnumMember]
        Savings = 1
    }

    [DataContract]
    public enum BankAccountStatus
    {
        [EnumMember]
        Verified = 0,
        [EnumMember]  
        InProgress = 1,
        [EnumMember]
        Logged = 2        
    }
}
