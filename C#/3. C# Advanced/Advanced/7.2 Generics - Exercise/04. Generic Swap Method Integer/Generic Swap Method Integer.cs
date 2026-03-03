namespace GenericSwapMethodInteger;

class Program
{
    static void Main(string[] args)
    {
        int boxesCount = int.Parse(Console.ReadLine());
        List<int> list = new();

        for (int i = 1; i <= boxesCount; i++)
        {
            int box = int.Parse(Console.ReadLine());
            list.Add(box);
        }

        int[] swap = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int firstIndex = swap[0];
        int secondIndex = swap[1];

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
