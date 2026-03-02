using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models;

public class AddCollection : IAddable
{
    private readonly List<string> data = new();

    public int Add(string item)
    {
        data.Add(item);

        return data.Count - 1;
    }
}
