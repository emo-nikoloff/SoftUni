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
