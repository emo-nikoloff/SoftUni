using System.Text;

namespace _09._Simple_Text_Editor;

class Program
{
    static void Main(string[] args)
    {
        int operationsNumber = int.Parse(Console.ReadLine());
        StringBuilder text = new();
        Stack<string> states = new();
        for (int i = 0; i < operationsNumber; i++)
        {
            string[] commandTokens = Console.ReadLine().Split();
            switch (commandTokens[0])
            {
                case "1":
                    string someString = commandTokens[1];
                    states.Push(text.ToString());
                    text.Append(someString);
                    break;
                case "2":
                    int elementsCount = int.Parse(commandTokens[1]);
                    states.Push(text.ToString());
                    text.Remove(text.Length - elementsCount, elementsCount);
                    break;
                case "3":
                    int index = int.Parse(commandTokens[1]) - 1;
                    Console.WriteLine(text[index]);
                    break;
                case "4":
                    text = new StringBuilder(states.Pop());
                    break;
            }
        }
    }
}
