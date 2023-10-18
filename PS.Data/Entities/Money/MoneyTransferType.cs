using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.Money
{
    [DataContract]
    public enum MoneyTransferType
    {
        [EnumMember]
        TransferAsBonus = 0,
        [EnumMember]
        TransferAsFixedPrice = 1,
        [EnumMember]
        TransferAsHourly = 2,
        [EnumMember]
        TransferAsPresent = 3,
        [EnumMember]
        Other = 4,
    }
}