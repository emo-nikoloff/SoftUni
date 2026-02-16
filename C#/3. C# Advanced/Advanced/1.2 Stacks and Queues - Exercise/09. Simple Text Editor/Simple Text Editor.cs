/*You are given an empty text. Your task is to implement 4 commands related to manipulating the text
· 1 someString - appends someString to the end of the text.
· 2 count - erases the last count elements from the text.
· 3 index - returns the element at position index from the text.
· 4 - undoes the last not undone command of type 1 or 2 and returns the text to the state before that operation.*/
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
