using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.Money
{
    [DataContract]
    public enum MoneyLoadType
    {        
        [EnumMember]
        PayPal = 0,
        [EnumMember]
        CreditCard = 1,
    }
}
