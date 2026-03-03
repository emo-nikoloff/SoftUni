namespace _01._Basic_Stack_Operations;

class Program
{
    static void Main(string[] args)
    {
        int[] setup = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = setup[0], s = setup[1], x = setup[2];

        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Stack<int> stack = new();

        for (int i = 0; i < n; i++)
        {
            stack.Push(numbers[i]);
        }

        for (int i = 0; i < s; i++)
        {
            stack.Pop();
        }

        if (stack.Count == 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            int min = int.MaxValue;
            bool isFound = false;
            while (stack.Count > 0)
            {
                int number = stack.Pop();
                if (!isFound && number == x) isFound = true;

                min = Math.Min(min, number);
            }

            if (isFound)
            {
                Console.WriteLine(isFound.ToString().ToLower());
            }
            else
            {
                Console.WriteLine(min);
            }
        }
    }
}
