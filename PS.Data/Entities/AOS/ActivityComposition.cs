using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class ActivityComposition : Entity
    {
        [DataMember]
        public string ExternalActivityID { get; set; }
        [DataMember]
        public string ActivityID { get; set; }
        [DataMember]
        public Int32 Sequence { get; set; }
        [DataMember]
        public float MinimumDuration { get; set; }
        [DataMember]
        public float MaximumDuration { get; set; }
        [DataMember]
        public float OptimumDuration { get; set; }
        [DataMember]
        public string[] ActivityToolId { get; set; }
        [DataMember]
        public string AllCaptureTimeId { get; set; }
        [DataMember]
        public string AllowedTimeId { get; set; }
        [DataMember]
        public string[] KeywordDictionaryIds { get; set; }
        [DataMember]
        public int CaptureInterval { get; set; }
        [DataMember]
        public int VariationFactor { get; set; }

        //New Added parameters based on Feature List
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime DueDate { get; set; }
        [DataMember]
        public string ActivityTypeId { get; set; }
        [DataMember]
        public float ActualDuration { get; set; }
        [DataMember]
        public float AdditionalTime { get; set; }
        [DataMember]
        public string CreatedById { get; set; }
        [DataMember]
        public string PriorityId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime CompletionDate { get; set; }
        [DataMember]
        public string ActualOutput { get; set; }
        [DataMember]
        public string ExpectedOutput { get; set; }
        [DataMember]
        public ActivityCaptureType ActivityCaptureType { get; set; }
    }
    public enum ActivityCaptureType
    {
        TimeInterval,
        KeywordMatch
    }
}
