namespace EnterNumbers;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new();

        int startNumber = 1;

        while (numbers.Count < 10)
        {
            try
            {
                int number = ReadNumber(startNumber, 100);
                numbers.Add(number);
                startNumber = number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number!");
                continue;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(string.Join(", ", numbers));
    }

    static int ReadNumber(int start, int end)
    {
        int number = int.Parse(Console.ReadLine());

        if (number <= start || number >= end)
        {
            throw new ArgumentException($"Your number is not in range {start} - 100!");
        }

        return number;
    }
}

