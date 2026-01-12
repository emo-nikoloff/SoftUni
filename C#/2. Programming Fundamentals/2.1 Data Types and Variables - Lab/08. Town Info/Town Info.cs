/*You will be given 3 lines of input. On the first line, you will be given the name of the town, on the second – the population and on the third
the area. Use the correct data types and print the result in the following format:
"Town {town name} has population of {population} and area {area} square km".*/
using System;

namespace _08._Town_Info;

class Program
{
    static void Main(string[] args)
    {
        string town = Console.ReadLine();
        decimal population = decimal.Parse(Console.ReadLine());
        int area = int.Parse(Console.ReadLine());

        Console.WriteLine($"Town {town} has population of {population} and area {area} square km.");
    }
}
