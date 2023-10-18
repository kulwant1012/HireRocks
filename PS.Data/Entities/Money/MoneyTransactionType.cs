using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.Money
{
    [DataContract]
    public enum MoneyTransactionType
    {        
        [EnumMember]
        LoadMoney = 0,
        [EnumMember]
        TransferMoney = 1,
        [EnumMember]
        WithdrawMoney = 2,
    }
}
