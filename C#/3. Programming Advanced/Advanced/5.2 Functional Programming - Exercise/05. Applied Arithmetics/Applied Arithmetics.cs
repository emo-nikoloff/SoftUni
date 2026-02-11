namespace _05._Applied_Arithmetics;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        Func<int, int> operation = null;
        Action<List<int>> print = numbers =>
        {
            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        };

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "end")
        {
            switch (command)
            {
                case "add":
                    operation = number => number + 1;
                    break;
                case "multiply":
                    operation = number => number * 2;
                    break;
                case "subtract":
                    operation = number => number - 1;
                    break;
                case "print":
                    print(numbers);
                    continue;
            }

            numbers = numbers.Select(n => operation(n)).ToList();
        }
    }
}
