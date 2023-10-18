using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.Money
{
    [DataContract]
    public class MoneyTransaction : Entity
    {
        [DataMember]
        public string FromUserId { get; set; }

        [DataMember]
        public string ToUserId { get; set; }

        [DataMember]
        public double Amount { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public MoneyTransactionType Type { get; set; }

        [DataMember]
        public MoneyTransactionStatus Status  { get; set; }

        [DataMember]
        public MoneyLoadDetail MoneyLoadDetail { get; set; }

        [DataMember]
        public MoneyTransferDetail MoneyTransferDetail { get; set; }

        [DataMember]
        public MoneyWithdrawDetail MoneyWithdrawDetail { get; set; }

        [DataMember]
        public DateTime DateUpdated { get; set; }

        [DataMember]
        public DateTime DatePosted { get; set; }

        [DataMember]
        public string PushChannel { get; set; }
    }    
}
