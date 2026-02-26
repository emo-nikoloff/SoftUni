namespace _01._Person;

class Program
{
    static void Main(string[] args)
    {
        Person person = new("Ime", 96);
        Console.WriteLine(person);

        Child child = new("BezIme", 69);
        Console.WriteLine(child);
    }
}
