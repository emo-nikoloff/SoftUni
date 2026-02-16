/*Write a program that receives an integer N on the first line. On the next N lines, read pairs of "[name], [age]". Then read three lines:
· Condition - "younger" (<) or "older" (>=)
· Age threshold - integer
· Format - "name", "age" or "name age"
Depending on the condition, print the correct pairs in the correct format. Don't use the built-in functionality from .NET. Create your own methods.*/
namespace _05._Filter_By_Age;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new();

        int peopleCount = int.Parse(Console.ReadLine());
        for (int i = 1; i <= peopleCount; i++)
        {
            string[] input = Console.ReadLine().Split(", ");
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new(name, age);
            people.Add(person);
        }

        string condition = Console.ReadLine();
        int ageThreshold = int.Parse(Console.ReadLine());
        string format = Console.ReadLine();

        Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
        Action<Person> printer = CreatePrinter(format);
        PrintFilteredPeople(people, filter, printer);
    }

    static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
    {
        switch (condition)
        {
            case "younger":
                return p => p.Age < ageThreshold;
            case "older":
                return p => p.Age >= ageThreshold;
            default:
                throw new ArgumentException(condition);
        }
    }

    static Action<Person> CreatePrinter(string format)
    {
        switch (format)
        {
            case "name":
                return p => Console.WriteLine($"{p.Name}");
            case "age":
                return p => Console.WriteLine($"{p.Age}");
            case "name age":
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            default:
                throw new ArgumentException(format);
        }
    }

    static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
    {
        people.Where(filter).ToList().ForEach(printer);
    }
}

class Person
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
