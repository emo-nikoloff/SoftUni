namespace MathOperations;

class Program
{
    static void Main(string[] args)
    {
        MyMathClass mathClass = new();
        Console.WriteLine(mathClass.Sum(2, 3));
    }
}
