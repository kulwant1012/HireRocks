using System;
using PS.Data.Entities;

namespace PS.Data.Interfaces
{
    public interface IQSpace
    {
        long Id { get; set; }

        /// <summary>
        /// The name or title of the current QSpace
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Current energy level of this Qspace.  This is
        /// </summary>
        EnergyLevel EnergyLevel { get; set; }

        /// <summary>
        /// The type of the current QSpace.
        /// </summary>
        SectorType Type { get; set; }

        /// <summary>
        /// The group that the current QSpace belongs
        /// </summary>
        int GroupId { get; set; }

        /// <summary>
        /// The current sector ID that this QSpace belongs.  This can be used to seperate users into smaller groups.
        /// </summary>
        int SectorId { get; set; }

        DateTime Created { get; set; }

        /// <summary>
        /// The current owner of this Qspace
        /// </summary>
        string OwnerId { get; set; }
    }
}