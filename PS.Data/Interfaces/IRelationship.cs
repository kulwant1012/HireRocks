using System;

namespace PS.Data.Interfaces
{
    public interface IRelationship
    {
        /// <summary>
        /// The unique id of the relationship
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// The parent Id defined in this relationship
        /// </summary>
        long ParentId { get; set; }

        /// <summary>
        /// The QSpace Id defined in this relationship
        /// </summary>
        long QsId { get; set; }

        ///// <summary>
        ///// The dataId defined in this relationship
        ///// </summary>
        //long DataId { get; set; }

        /// <summary>
        /// Determines if this relationship is enabled or disabled
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Date this relationship was created.
        /// </summary>
        DateTime Created { get; set; }
    }
}