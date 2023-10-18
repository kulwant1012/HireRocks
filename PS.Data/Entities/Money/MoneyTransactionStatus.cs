using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.Money
{
    [DataContract]
    public enum MoneyTransactionStatus
    {
        [EnumMember]
        InProcess = 0,
        [EnumMember]
        Processed = 1,
        [EnumMember]
        Error = 5,
    }
}
