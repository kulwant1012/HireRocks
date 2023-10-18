using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.Money
{
    [DataContract]
    public class MoneyTransferDetail : Entity
    {
        [DataMember]
        public MoneyTransferType Type { get; set; }
        
        [DataMember]
        public string Memo { get; set; }
    }
}
