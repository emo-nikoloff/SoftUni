using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models;

public class AddRemoveCollection : IRemovable
{
    private readonly Queue<string> data = new();

    public int Add(string item)
    {
        data.Enqueue(item);

        return 0;
    }

    public string Remove() => data.Dequeue();
}
