/*Use your Person class from the previous tasks. Create a class Family. The class should have a list of people, a method for adding members - void AddMember(Person member) and a method returning
the oldest family member – Person GetOldestMember(). Write a program that reads the names and ages of N people and adds them to the family. Then print the name and age of the oldest member.*/
namespace DefiningClasses;

public class OldestFamilyMember
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
        Console.WriteLine(family.GetOldestMember());
    }
}
