using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities
{
  public class EmailVerification:QSpace
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string NewEmail { get; set; }

        [DataMember]
        public string VerificationCode { get; set; }

        [DataMember]
        public bool Verified { get; set; }

        [DataMember]
        public int NumberOfAttempts { get; set; }

    }
}
