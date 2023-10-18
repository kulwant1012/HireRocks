
namespace PS.Data.Interfaces
{
    public interface IEntity
    {
        string Id { get; set; }
    }

    public interface INamedEntity : IEntity
    {
        string Name { get; set; }
    }
}
