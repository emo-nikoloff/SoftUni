namespace _05._Date_Modifier;

public class DateModifier
{
    public static int DaysDifference(string firstDate, string secondDate)
    {
        DateTime first = DateTime.Parse(firstDate);
        DateTime second = DateTime.Parse(secondDate);

        TimeSpan difference = first - second;
        return (int)Math.Abs(difference.TotalDays);
    }
}
