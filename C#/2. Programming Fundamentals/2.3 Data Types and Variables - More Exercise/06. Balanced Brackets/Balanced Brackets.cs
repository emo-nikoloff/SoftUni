/*You will receive n lines. On those lines, you will receive one of the following:
· Opening bracket – '(',
· Closing bracket – ')' or
· Random string
Your task is to find out if the brackets are balanced. That means after every opening bracket should follow an closing one. Nested parentheses are not valid and if two consecutive opening brackets
exist, the expression should be marked as unbalanced.
· On the first line, you will receive n – the number of lines, which will follow.
· On the next n lines, you will receive '(', ')' or another string.
You have to print "BALANCED", if the parentheses are balanced and "UNBALANCED" otherwise.*/
using System;

namespace _06._Balanced_Brackets;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        bool waitingForClosing = false;

        for (int line = 1; line <= lines; line++)
        {
            string input = Console.ReadLine();

            if (input == "(")
            {
                if (waitingForClosing)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
                waitingForClosing = true;
            }
            else if (input == ")")
            {
                if (!waitingForClosing)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
                waitingForClosing = false;
            }
        }

        if (waitingForClosing)
        {
            Console.WriteLine("UNBALANCED");
        }
        else
        {
            Console.WriteLine("BALANCED");
        }
    }
}
