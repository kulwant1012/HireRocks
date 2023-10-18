using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.Money
{
    [DataContract]
    public class PayPalInfo : Entity
    {
        [DataMember]
        public string PayPalAccount { get; set; }
    }
}
