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
    public class BackupTask : Entity
    {
        [DataMember]
        [Display(Name = "Task Name")]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "Storage Account Name")]
        [Required]
        public string SourceStorageAccountName { get; set; }

        [DataMember]
        [Display(Name = "Storage Account Key")]
        [Required]
        public string SourceStorageAccountKey { get; set; }

        [DataMember]
        [Display(Name = "Container")]
        [Required]
        public string SourceStorageContainer { get; set; }

        [DataMember]
        [Display(Name = "Storage Account Name")]
        [Required]
        public string DestinationStorageAccountName { get; set; }

        [DataMember]
        [Display(Name = "Storage Account Key")]
        [Required]
        public string DestinationStorageAccountKey { get; set; }

        [DataMember]
        [Display(Name = "Container")]
        [Required]
        public string DestinationStorageContainer { get; set; }

        [DataMember]
        [Display(Name = "Backup Day")]        
        public BackupDay BackupDay { get; set; }

        [DataMember]
        [Display(Name = "Backup Time")]
        [Required]
        public TimeSpan BackupTime { get; set; }

        [DataMember]
        [Display(Name = "Time Zone")]
        [Required]
        public string BackupTimeZone { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]        
        public DateTime ModifyDate { get; set; }

        [DataMember]
        public string UserId { get; set; }

        public BackupTask()
        {
            BackupTime = TimeSpan.FromHours(6);
            BackupDay = Entities.BackupDay.EveryDay;
            BackupTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time").Id;
        }
    }    
}
