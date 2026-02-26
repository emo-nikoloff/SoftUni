namespace CustomStack;

public class StartUp
{
    static void Main(string[] args)
    {
        StackOfStrings stackStrings = new();
        Console.WriteLine(stackStrings.IsEmpty());

        stackStrings.Push("Silviya");
        Console.WriteLine(stackStrings.IsEmpty());

        stackStrings.AddRange(new List<string>() { "Ismail", "Halapenyo", "Kiril" });
    }
}
