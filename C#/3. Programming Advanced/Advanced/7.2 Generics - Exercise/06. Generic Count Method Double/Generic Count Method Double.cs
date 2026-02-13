namespace GenericCountMethodDouble;

public class Program
{
    static void Main(string[] args)
    {
        int elements = int.Parse(Console.ReadLine());
        List<double> list = new();

        for (int i = 1; i <= elements; i++)
        {
            double element = double.Parse(Console.ReadLine());
            list.Add(element);
        }

        double compare = double.Parse(Console.ReadLine());

        Console.WriteLine(CountGreater(list, compare));
    }

    static int CountGreater<T>(List<T> list, T compare) where T : IComparable<T>
    {
        int count = 0;
        foreach (T element in list)
        {
            if (element.CompareTo(compare) > 0)
            {
                count++;
            }
        }
        return count;
    }
}
