namespace CustomStack.Models;

public class StackOfStrings : Stack<string>
{
    public bool IsEmpty()
    {
        return Count == 0;
    }

    public Stack<string> AddRange(IEnumerable<string> items)
    {
        foreach (string item in items)
        {
            Push(item);
        }

        return this;
    }
}
