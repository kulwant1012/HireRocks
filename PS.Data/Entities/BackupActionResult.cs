using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities
{
    [DataContract]
    public class BackupActionResult
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        public BackupActionResult()
        {
            IsSuccess = true;
        }
    }    
}
