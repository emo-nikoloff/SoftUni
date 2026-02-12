namespace GenericBoxofInteger;

class Program
{
    static void Main(string[] args)
    {
        int integers = int.Parse(Console.ReadLine());
        List<Box<int>> boxes = new();

        for (int i = 1; i <= integers; i++)
        {
            int number = int.Parse(Console.ReadLine());
            Box<int> box = new(number);
            boxes.Add(box);
        }

        foreach (Box<int> box in boxes)
        {
            Console.WriteLine(box);
        }
    }
}
