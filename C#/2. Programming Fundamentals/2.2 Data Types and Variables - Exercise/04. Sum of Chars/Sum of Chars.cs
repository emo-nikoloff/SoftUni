/*Create a program, which sums the ASCII codes of n characters and prints the sum on the console.
· On the first line, you will receive n – the number of lines, which will follow.
· On the next n lines – you will receive letters from the Latin alphabet.
Print the total sum in the following format:
"The sum equals: {totalSum}"*/
using System;

namespace _04._Sum_of_Chars;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());

        int sum = 0;
        for (int line = 1; line <= lines; line++)
        {
            char letter = char.Parse(Console.ReadLine());
            sum += letter;
        }

        Console.WriteLine($"The sum equals: {sum}");
    }
}
