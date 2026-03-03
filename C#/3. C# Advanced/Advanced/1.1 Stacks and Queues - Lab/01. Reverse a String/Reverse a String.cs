namespace _01._Reverse_a_String;

class Program
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();

        Stack<char> charsStack = new();

        foreach (char character in text)
        {
            charsStack.Push(character);
        }

        while (charsStack.Count > 0)
        {
            Console.Write(charsStack.Pop());
        }
    }
}
