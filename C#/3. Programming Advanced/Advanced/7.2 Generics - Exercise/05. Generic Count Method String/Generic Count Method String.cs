/*Create a method that receives as an argument a list of any type, that can be compared and an element of the given type. The method should return the count of elements that are greater than the
value of the given element. Modify your Box class to support comparison by the value of the stored data.*/
namespace GenericCountMethodString;

class Program
{
    static void Main(string[] args)
    {
        int elements = int.Parse(Console.ReadLine());
        List<string> list = new();

        for (int i = 1; i <= elements; i++)
        {
            string element = Console.ReadLine();
            list.Add(element);
        }

        string compare = Console.ReadLine();

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
