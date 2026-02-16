/*Create a simple calculator that can evaluate simple expressions with only addition and subtraction. There will not be any parentheses. Numbers and operations are space-separated. Solve the
problem using a Stack.*/
namespace _03._Simple_Calculator;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        Array.Reverse(input); // обръщаме масива, за да може да се подреди правилно в стека
        Stack<string> stack = new(input);

        int sum = int.Parse(stack.Pop());
        while (stack.Count > 0)
        {
            string operation = stack.Pop();
            int currentNumber = int.Parse(stack.Pop());

            switch (operation)
            {
                case "+":
                    sum += currentNumber;
                    break;
                case "-":
                    sum -= currentNumber;
                    break;
            }
        }

        Console.WriteLine(sum);
    }
}
