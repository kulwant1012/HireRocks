using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.Money
{
    [DataContract]
    public class BankAccount : Entity
    {
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string RoutingNumber { get; set; }
        [DataMember]
        public BankAccountType AccountType { get; set; }
        [DataMember]
        public BankAccountStatus Status { get; set; }
        [DataMember]
        public string AccountNickName { get; set; }
        [DataMember]
        public string LegalNameOnBankAccount { get; set; }
        [DataMember]
        public string BankAddress { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string Comments { get; set; }
        [DataMember]
        public float? VerificationTransaction1Amount { get; set; }
        [DataMember]
        public float? VerificationTransaction2Amount { get; set; }
        [DataMember]
        public int VerificationAttemptsLeft { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime UpdatedDate { get; set; }
        [DataMember]
        public string FIUrl { get; set; }
        [DataMember]
        public string FIId { get; set; }
        [DataMember]
        public string FIOrganization { get; set; }
        [DataMember]
        public string OFXAppId { get; set; }
        [DataMember]
        public string OFXAppVersion { get; set; }
        [DataMember]
        public string OFXVersion { get; set; }
        [DataMember]
        public string OFXUser { get; set; }
        [DataMember]
        public string OFXPassword { get; set; }
    }
}
