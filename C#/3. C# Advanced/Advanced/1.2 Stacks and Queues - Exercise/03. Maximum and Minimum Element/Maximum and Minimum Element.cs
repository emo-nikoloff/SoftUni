/*You have an empty sequence and you will be given N queries. Each query is one of these three types:
1 x – Push the element x into the stack.
2 – Delete the element present at the top of the stack.
3 – Print the maximum element in the stack.
4 – Print the minimum element in the stack.
After you go through all of the queries, print the stack in the following format:
"{n}, {n1}, {n2} …, {nn}"*/
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
