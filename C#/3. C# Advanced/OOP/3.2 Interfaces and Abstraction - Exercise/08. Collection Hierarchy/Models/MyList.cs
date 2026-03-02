using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models;

public class MyList : ICountable
{
    private readonly Stack<string> stack = new();

    public int Count => stack.Count;

    public int Add(string item)
    {
        stack.Push(item);

        return 0;
    }

    public string Remove() => stack.Pop();
}
