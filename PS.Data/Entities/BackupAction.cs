using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities
{
    [DataContract]
    public class BackupAction : Entity
    {
        [DataMember]
        public string BackupTaskId { get; set; }

        [DataMember]
        [Display(Name = "Task Name")]
        public BackupTask BackupTask { get; set; }

        [DataMember]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [DataMember]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [DataMember]
        public TimeSpan BackupTime { get; set; }

        [DataMember]
        [Display(Name = "Result Files")]
        public List<string> BlobsList { get; set; }

        [DataMember]
        public BackupActionResult Result { get; set;}

        public BackupAction()
            :this(null)
        {
            
        }

        public BackupAction(string backupTaskId)            
        {
            BackupTaskId = backupTaskId;
            Result = new BackupActionResult();
            BlobsList = new List<string>();            
        }
    }    
}
