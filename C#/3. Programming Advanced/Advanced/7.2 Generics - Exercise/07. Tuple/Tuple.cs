/*A Tuple is a class in C#, in which you can store a few objects. First, we are going to focus on the Tuple's type, which contains two objects. The first one is "item1" and the second one is
"item2". It is kind of like a KeyValuePair, except – it simply has items, which are neither key nor value. Your task is to create a class "Tuple", which holds two objects. The first one will be
"item1" and the second one – "item2". The tricky part here is to make the class hold generics. This means, that when you create a new object of class – "Tuple", there should be a way to
explicitly specify both items' types separately.*/
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
