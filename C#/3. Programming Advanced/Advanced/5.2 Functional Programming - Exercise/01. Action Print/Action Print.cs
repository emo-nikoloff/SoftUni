/*Create a program that reads a collection of strings from the console and then prints them onto the console. Each name should be printed on a new line. Use Action<T>.*/
namespace _01._Action_Print;

class Program
{
    static void Main(string[] args)
    {
        Action<string> print = name => Console.WriteLine(name);
        string[] input = Console.ReadLine().Split();
        foreach (string name in input)
        {
            print(name);
        }
    }
}
