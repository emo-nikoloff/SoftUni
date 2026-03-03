namespace _04._Even_Times;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        Dictionary<int, int> occurences = new();
        for (int i = 1; i <= count; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (!occurences.ContainsKey(number))
            {
                occurences.Add(number, 1);
                continue;
            }
            occurences[number]++;
        }

        Console.WriteLine(occurences.Single(n => n.Value % 2 == 0).Key);
    }
}
