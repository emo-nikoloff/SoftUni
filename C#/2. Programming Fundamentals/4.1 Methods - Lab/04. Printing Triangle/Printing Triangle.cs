/*Create a method for printing triangles as shown below:
*Hints
1. After you read the input
2. Start by creating a method for printing a single line from a given start to a given end. Choose a meaningful name for it, describing its purpose
3. Create another method for printing the whole triangle. Again choose a meaningful name for it, describing its purpose
4. Think how you can use the PrintLine() method to solve the problem
5. After you spent some time thinking, you should have concluded that you need two loops
6. In the first loop you can print the first half of the triangle
7. In the second loop you can print the second half of the triangle*/
using System;

namespace _04._Printing_Triangle;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());

        PrintTriangle(magicNumber);
    }

    static void PrintLine(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }

    static void PrintTriangle(int lines)
    {
        for (int i = 1; i <= lines; i++)
        {
            PrintLine(1, i);
        }

        for (int i = lines - 1; i >= 1; i--)
        {
            PrintLine(1, i);
        }
    }
}
