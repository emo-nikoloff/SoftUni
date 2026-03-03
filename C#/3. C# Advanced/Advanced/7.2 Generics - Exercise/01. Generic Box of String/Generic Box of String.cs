namespace GenericBoxOfString;

public class Program
{
    static void Main(string[] args)
    {
        int strings = int.Parse(Console.ReadLine());
        List<Box<string>> boxes = new();

        for (int i = 1; i <= strings; i++)
        {
            string @string = Console.ReadLine();
            Box<string> box = new(@string);
            boxes.Add(box);
        }

        foreach (Box<string> box in boxes)
        {
            Console.WriteLine(box);
        }
    }
}
