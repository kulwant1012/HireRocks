using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AVS
{
    [DataContract]
    public class ActivityCapture : Entity
    {
        [DataMember]
        public string ActivityUserID { get; set; }
        [DataMember]
        public string ThumbnailImage { get; set; }
        [DataMember]
        public string FullImage { get; set; }
        [DataMember]
        public string Keyboard { get; set; }
        [DataMember]
        public string Mouse { get; set; }
        [DataMember]
        public DateTime CaptureDateTime { get; set; }
        [DataMember]
        public string ActivityDetails { get; set; }
        [DataMember]
        public TimeSpan TimeBurned { get; set; }
        [DataMember]
        public string[] MatchedKeywordIds { get; set; }
        [DataMember]
        public int KeywordsMatchCount { get; set; }
        [DataMember]
        public bool IsSyncToOTN { get; set; }
        [DataMember]
        public VerificationStatus VerificationStatus { get; set; }
    }

    public class VerificationStatus
    {
        public bool IsValid { get; set; }
        public bool IsOverdue { get; set; }
        public bool IsAccepted { get; set; }
        public string VerifierComments { get; set; }
        public string VerifierId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
