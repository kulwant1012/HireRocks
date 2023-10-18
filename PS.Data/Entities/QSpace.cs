
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PS.Data.Entities
{
    [DataContract]
    public class QSpace : Entity
    {        
        /// <summary>
        /// Current energy level of this Qspace.  This is
        /// </summary>
        [DataMember]
        public EnergyLevel EnergyLevel { get; set; }

        ///<summary>
        ///The type of the current QSpace.
        ///</summary>
        [DataMember]
        public SectorType Sector { get; set; }

        [DataMember]
        public uint QScore { get; set; }

        /// <summary>
        /// The date this QSpace was created
        /// </summary>
        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public List<string> ParentQSpaces { get; set; }

        [DataMember]
        public List<string> ChildQspaces { get; set; }

        [DataMember]
        public List<QSpaceRole> Role { get; set; }

        [DataMember]
        public bool CanProduceTasks { get; set; }        
    }
}
