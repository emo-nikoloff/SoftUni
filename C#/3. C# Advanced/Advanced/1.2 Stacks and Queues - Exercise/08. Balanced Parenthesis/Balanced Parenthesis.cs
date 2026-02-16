/*Given a sequence consisting of parentheses, determine whether the expression is balanced. A sequence of parentheses is balanced, if every open parenthesis can be paired uniquely with a closing
parenthesis that occurs after the former. Also, the interval between them must be balanced. You will be given three types of parentheses: (, {, and [.
{[()]} - This is a balanced parenthesis.
{[(])} - This is not a balanced parenthesis.*/
namespace _08._Balanced_Parenthesis;

class Program
{
    static void Main(string[] args)
    {
        char[] expression = Console.ReadLine().ToCharArray();
        Stack<char> openBrackets = new();

        bool isBalanced = false;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(' || expression[i] == '[' || expression[i] == '{')
            {
                openBrackets.Push(expression[i]);
            }
            else
            {
                isBalanced = true;
                if (openBrackets.Count == 0)
                {
                    isBalanced = false;
                    break;
                }
                char openBracket = openBrackets.Pop();
                char closingBracket = expression[i];

                switch (closingBracket)
                {
                    case ')':
                        if (openBracket != '(')
                        {
                            isBalanced = false;
                        }
                        break;
                    case ']':
                        if (openBracket != '[')
                        {
                            isBalanced = false;
                        }
                        break;
                    case '}':
                        if (openBracket != '{')
                        {
                            isBalanced = false;
                        }
                        break;
                }

                if (!isBalanced)
                {
                    break;
                }
            }
        }

        if (isBalanced)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}
