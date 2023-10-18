namespace PS.Data.Interfaces
{
    public interface IEntityType
    {
        /// <summary>
        /// The Id of the current entity
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// The name of the entity
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The assembly that the entity belongs to
        /// </summary>
        string Assembly { get; set; }

        /// <summary>
        /// The namespace that the entity belongs to
        /// </summary>
        string Namespace { get; set; }
    }
}