using System;

namespace DefiningClasses;

public class OpinionPoll
{
    static void Main(string[] args)
    {
        int people = int.Parse(Console.ReadLine());
        Family family = new();

        for (int i = 1; i <= people; i++)
        {
            string[] info = Console.ReadLine().Split();
            string name = info[0];
            int age = int.Parse(info[1]);

            Person person = new(name, age);
            family.AddMember(person);
        }

        foreach (Person member in family.Members.Where(m => m.Age > 30).OrderBy(m => m.Name))
        {
            Console.WriteLine(member);
        }
    }
}
