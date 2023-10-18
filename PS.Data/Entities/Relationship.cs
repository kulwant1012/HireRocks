
using System;
using System.Runtime.Serialization;
using PS.Data.Interfaces;

namespace PS.Data.Entities
{
    [DataContract]
    public class Relationship : IRelationship
    {
        /// <summary>
        /// The unique id of the relationship
        /// </summary>
        [DataMember]
        public virtual long Id { get; set; }

        /// <summary>
        /// The parent Id defined in this relationship
        /// </summary>
        [DataMember]
        public virtual long ParentId { get; set; }

        /// <summary>
        /// The QSpace Id defined in this relationship
        /// </summary>
        [DataMember]
        public virtual long QsId { get; set; }

        ///// <summary>
        ///// The dataId defined in this relationship
        ///// </summary>
        //[DataMember]
        //public virtual long DataId { get; set; }

        /// <summary>
        /// Determines if this relationship is enabled or disabled
        /// </summary>
        [DataMember]
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// Date this relationship was created.
        /// </summary>
        [DataMember]
        public virtual DateTime Created { get; set; }
    }
}
