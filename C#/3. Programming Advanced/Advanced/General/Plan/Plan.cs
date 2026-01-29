namespace Plan;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---Стек---");
        Stack<int> stack = new(); // LIFO => Last in - First out -> елементите се нареждат един върху друг, а не един до друг; последният влязъл елемент е и първият излязъл

        for (int i = 1; i <= 5; i++)
        {
            stack.Push(i); // вкарва елемент на върха на стека
        }

        Console.WriteLine($"Елементът на върха: {stack.Peek()}"); // връща елемента на върха

        Console.WriteLine("Елементите в стека:");
        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop()); // взима елемента на върха
        }
    }
}
