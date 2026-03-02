using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Citizen> citizens = new();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = inputInfo[0];
            string country = inputInfo[1];
            int age = int.Parse(inputInfo[2]);

            Citizen citizen = new(name, country, age);

            citizens.Add(citizen);
        }

        foreach (Citizen citizen in citizens)
        {
            Console.WriteLine(((IPerson)citizen).GetName());
            Console.WriteLine(((IResident)citizen).GetName());
        }
    }
}
