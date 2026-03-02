namespace CollectionHierarchy.Models.Interfaces;

public interface ICountable : IRemovable
{
    int Count { get; }
}
