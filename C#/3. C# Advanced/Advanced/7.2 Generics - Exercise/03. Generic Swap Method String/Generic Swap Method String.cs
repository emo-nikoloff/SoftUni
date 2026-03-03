namespace GenericSwapMethodString;

public class Program
{
    static void Main(string[] args)
    {
        int boxesCount = int.Parse(Console.ReadLine());
        List<string> list = new();

        for (int i = 1; i <= boxesCount; i++)
        {
            string box = Console.ReadLine();
            list.Add(box);
        }

        string[] swap = Console.ReadLine().Split();
        int firstIndex = int.Parse(swap[0]);
        int secondIndex = int.Parse(swap[1]);

        SwapElements(list, firstIndex, secondIndex);
    }

    static void SwapElements<T>(List<T> list, int firstIndex, int secondIndex)
    {
        T temp = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temp;

        list.ForEach(e => Console.WriteLine($"{typeof(T)}: {e}"));
    }
}
