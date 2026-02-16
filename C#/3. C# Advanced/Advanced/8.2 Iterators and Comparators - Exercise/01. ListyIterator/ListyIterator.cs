using System;
using System.Collections;

namespace ListyIterator;

public class ListyIterator<T> : IEnumerator<T>
{
    private List<T> list;
    private int index;

    public ListyIterator(List<T> list)
    {
        this.list = list;
        Reset();
    }

    public T Current
    {
        get
        {
            if (list == null || list.Count == 0 || index >= list.Count)
            {
                throw new InvalidOperationException("Invalid operation!");
            }
            return list[index];
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose() { }

    public bool MoveNext()
    {
        if (!HasNext())
        {
            return false;
        }
        index++;
        return true;
    }

    public bool HasNext()
    {
        if (index == list.Count - 1)
        {
            return false;
        }
        return true;
    }

    public void Reset()
    {
        index = 0;
    }
}
