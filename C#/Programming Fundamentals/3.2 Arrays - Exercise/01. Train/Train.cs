/*A train has n number of wagons (integer, received as input). On the next n lines, you will receive the number of people that are going to get on each wagon. Print out the number of passengers in
each wagon followed by the total number of passengers on the train.*/
using System;

namespace _01._Train;

class Program
{
    static void Main(string[] args)
    {
        int wagons = int.Parse(Console.ReadLine());
        int[] people = new int[wagons];

        int totalPeople = 0;
        for (int i = 1; i <= wagons; i++)
        {
            people[i] = int.Parse(Console.ReadLine());
            totalPeople += people[i];
        }
        Console.WriteLine($"{string.Join(" ", people)}\n{totalPeople}");
    }
}
