using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities
{
    [DataContract]
    public class Task : QSpace
    {                 
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public uint RewardPoints { get; set; }

        [DataMember]
        public uint EstimatedQscore { get; set; }

        [DataMember]
        public TimeSpan EstimatedTime { get; set; }

        [DataMember]
        public uint EstimatedBudget { get; set; }        

        [DataMember]
        public DateTime LastModifiedDate { get; set; }

        [DataMember]
        public DateTime FinishedDate { get; set; }

        [DataMember]
        public string CreatorId { get; set; }

        [DataMember]
        public string AssignedUsers { get; set; }
    }
}
