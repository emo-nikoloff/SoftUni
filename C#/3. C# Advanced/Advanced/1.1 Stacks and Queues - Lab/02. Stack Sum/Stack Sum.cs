namespace _02._Stack_Sum;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Stack<int> stack = new(numbers);

        string commandInfo = string.Empty;
        while ((commandInfo = Console.ReadLine().ToLower()) != "end")
        {
            string[] tokens = commandInfo.Split();
            string command = tokens[0].ToLower();

            switch (command)
            {
                case "add":
                    int firstNumber = int.Parse(tokens[1]);
                    int secondNumber = int.Parse(tokens[2]);

                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                    break;
                case "remove":
                    int numberElements = int.Parse(tokens[1]);

                    if (stack.Count >= numberElements)
                    {
                        for (int i = 0; i < numberElements; i++)
                        {
                            stack.Pop();
                        }
                    }
                    break;
            }
        }

        Console.WriteLine($"Sum: {stack.Sum()}");
    }
}
