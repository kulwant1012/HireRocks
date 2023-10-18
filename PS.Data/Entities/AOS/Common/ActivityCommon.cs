using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities.AOS.Common
{
    [DataContract]
    public class ActivityCommon : Entity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public int PercentCompleted { get; set; }
        [DataMember]
        public Boolean PubliclyViewable { get; set; }
        [DataMember]
        public Boolean IsCompleted { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime DueDate { get; set; }
        [DataMember]
        public DateTime CompletionDate { get; set; }
        [DataMember]
        public string AssignedTo { get; set; }
        [DataMember]
        public string ReportedBy { get; set; }
        [DataMember]
        public string Project { get; set; }
        [DataMember]
        public string Priority { get; set; }
        [DataMember]
        public int EstimatedDuration { get; set; }
        [DataMember]
        public int ActualDuration { get; set; }
        [DataMember]
        public int RemainingDuration { get; set; }
        [DataMember]
        public int MinimumDuration { get; set; }
        [DataMember]
        public int MaximumDuration { get; set; }
        [DataMember]
        public int OptimumDuration { get; set; }
        [DataMember]
        public string WorkFlowStep { get; set; }
        [DataMember]
        public string Release { get; set; }
        [DataMember]
        public string[] ActivityToolId { get; set; }
        [DataMember]
        public string AllCaptureTimeID { get; set; }
        [DataMember]
        public string AllowedCaptureTimeId { get; set; }
        [DataMember]
        public string ActivityStatusId { get; set; }
        [DataMember]
        public string[] KeywordDictionaryId { get; set; }
        [DataMember]
        public int Sequence { get; set; }
        [DataMember]
        public string OtnActivityId { get; set; }
        [DataMember]
        public string AOSActivityId { get; set; }
    }
}
