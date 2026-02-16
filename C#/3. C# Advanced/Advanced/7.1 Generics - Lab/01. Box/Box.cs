using System;

namespace BoxOfT;

public class Box<T>
{
    private List<T> items;

    public Box()
    {
        items = new();
    }

    public int Count { get => items.Count; }

    public void Add(T element)
    {
        items.Add(element);
    }
    public T Remove()
    {
        int lastIndex = items.Count - 1;
        T lastElement = items[lastIndex];

        items.RemoveAt(lastIndex);
        return lastElement;
    }
}
