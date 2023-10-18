using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.Money
{
    [DataContract]
    public class Wallet : Entity
    {
        [DataMember]
        public double Balance { get; set; }

        [DataMember]
        public List<BankAccount> BankAccounts { get; set; }

        public Wallet()
        {
            BankAccounts = new List<BankAccount>();
        }
    }
}
