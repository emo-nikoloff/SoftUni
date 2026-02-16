/*Create a program that executes some mathematical operations on a given collection. On the first line, you are given a list of numbers. On the next lines, you are passed different commands that
you need to apply to all the numbers in the list:
· "add" -> add 1 to each number
· "multiply" -> multiply each number by 2
· "subtract" -> subtract 1 from each number
· "print" -> print the collection
· "end" -> ends the input
Note: Use functions.*/
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
