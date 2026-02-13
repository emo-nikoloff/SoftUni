namespace Tuple;

public class Program
{
    static void Main(string[] args)
    {
        Tuple<string, int, DateTime> tuple = new("Emiliyan", 25, DateTime.Now);

        string[] personInfo = Console.ReadLine().Split();
        string personFullName = $"{personInfo[0]} {personInfo[1]}";
        string personAddress = personInfo[2];
        CustomTuple<string, string> firstPerson = new(personFullName, personAddress);
        Console.WriteLine(firstPerson);

        string[] personDrinks = Console.ReadLine().Split();
        string personName = personDrinks[0];
        int personBeers = int.Parse(personDrinks[1]);
        CustomTuple<string, int> secondPerson = new(personName, personBeers);
        Console.WriteLine(secondPerson);

        string[] numbers = Console.ReadLine().Split();
        int firstNumber = int.Parse(numbers[0]);
        double secondNumber = double.Parse(numbers[1]);
        CustomTuple<int, double> digits = new(firstNumber, secondNumber);
        Console.WriteLine(digits);
    }
}
