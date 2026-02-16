/*Create a class DateModifier, which stores the difference of the days between two dates. It should have a method that takes two string parameters, representing dates as strings and calculates
the difference in the days between them.*/
namespace _05._Date_Modifier;

public class Program
{
    static void Main(string[] args)
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        int difference = DateModifier.DaysDifference(firstDate, secondDate);
        Console.WriteLine(difference);
    }
}
