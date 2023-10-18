using System;

namespace PS.Data.Interfaces
{
    public interface IQSpaceData
    {
        /// <summary>
        /// The primary key on the QSpaceData table
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// The QSpaceId that this data belongs to
        /// </summary>
        long QSpaceId { get; set; }

        /// <summary>
        /// Entity that holds all relavent information for loading the EntityData
        /// </summary>
        IEntityType EntityType { get; set; }

        /// <summary>
        /// The name of this instance of data.  This can be many different names.  Since the
        /// QSpace could have many different instances of the entity
        /// </summary>
        string Name { get; set; }


        /// <summary>
        /// The value of the object
        /// </summary>
        object EntityData { get; set; }

        /// <summary>
        /// Time this entity was created
        /// </summary>
        DateTime Created { get; set; }
    }
}