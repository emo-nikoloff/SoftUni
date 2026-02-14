namespace ListyIterator;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] create = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<string> elements = create[1..].ToList();
        ListyIterator<string> iterator = new(elements);

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "END")
        {
            switch (command)
            {
                case "Move":
                    Console.WriteLine(iterator.MoveNext());
                    break;
                case "HasNext":
                    Console.WriteLine(iterator.HasNext());
                    break;
                case "Print":
                    try
                    {
                        Console.WriteLine(iterator.Current);
                    }
                    catch (InvalidOperationException error)
                    {
                        Console.WriteLine(error.Message);
                    }
                    break;
            }
        }
    }
}
