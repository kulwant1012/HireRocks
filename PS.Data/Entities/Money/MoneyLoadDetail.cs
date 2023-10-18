using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.Money
{
    [DataContract]
    public class MoneyLoadDetail
    {        
        [DataMember]
        public MoneyLoadType MoneyLoadType { get; set; }

        /// <summary>
        /// Used only if MoneyLoadType == CreditCard
        /// </summary>
        [DataMember]
        public CreditCardInfo CreditCard { get; set; }

        /// <summary>
        /// Used only if MoneyLoadType == PayPal
        /// </summary>
        [DataMember]
        public PayPalInfo PayPal { get; set; }

        [DataMember]
        public string Memo { get; set; }
    }
}
