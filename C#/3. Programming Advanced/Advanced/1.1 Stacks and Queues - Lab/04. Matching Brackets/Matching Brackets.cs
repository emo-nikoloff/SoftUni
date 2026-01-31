/*We are given an arithmetic expression with brackets. Scan through the string and extract each sub-expression. Print the result back at the terminal.*/
namespace _04._Matching_Brackets;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Stack<int> stack = new();
        for (int i = 0; i < input.Length; i++)
        {
            char character = input[i];
            if (character == '(')
            {
                stack.Push(i);
            }
            else if (character == ')')
            {
                int startIndex = stack.Pop();
                string contents = input.Substring(startIndex, i - startIndex + 1);
                Console.WriteLine(contents);
            }
        }
    }
}
