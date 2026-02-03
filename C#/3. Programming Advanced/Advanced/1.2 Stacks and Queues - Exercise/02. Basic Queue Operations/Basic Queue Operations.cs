/*Play around with a queue. You will be given an integer N representing the number of elements to enqueue (add), an integer S, representing the number of elements to dequeue (remove) from the
queue, and finally an integer X, an element that you should look for in the queue. If it is, print true on the console. If it's not printed the smallest element is currently present in the queue.
If there are no elements in the sequence, print 0 on the console.*/
namespace _02._Basic_Queue_Operations;

class Program
{
    static void Main(string[] args)
    {
        int[] setup = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = setup[0], s = setup[1], x = setup[2];

        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Queue<int> queue = new();

        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(numbers[i]);
        }

        for (int i = 0; i < s; i++)
        {
            queue.Dequeue();
        }

        if (queue.Count == 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            int min = int.MaxValue;
            bool isFound = false;
            while (queue.Count > 0)
            {
                int number = queue.Dequeue();
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
