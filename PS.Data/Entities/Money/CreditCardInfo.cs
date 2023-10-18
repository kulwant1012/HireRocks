using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.Money
{
    [DataContract]
    public class CreditCardInfo : Entity
    {
        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public string CardHolder { get; set; }

        [DataMember]
        public int ValidToMonth { get; set; }

        [DataMember]
        public int ValidToYear { get; set; }

        [DataMember]
        public int CVV { get; set; }
    }
}
