namespace _03._Maximum_and_Minimum_Element;

class Program
{
    static void Main(string[] args)
    {
        int queriesNumber = int.Parse(Console.ReadLine());
        Stack<int> stack = new();

        for (int i = 0; i < queriesNumber; i++)
        {
            int[] queries = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int query = queries[0];
            switch (query)
            {
                case 1:
                    int number = queries[1];
                    stack.Push(number);
                    break;
                case 2:
                    stack.Pop();
                    break;
                case 3:
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    break;
                case 4:
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                    break;
            }
        }
        Console.WriteLine(string.Join(", ", stack));
    }
}
