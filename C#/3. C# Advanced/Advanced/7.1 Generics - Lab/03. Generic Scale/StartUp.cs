namespace _03._Generic_Scale;

class Program
{
    static void Main(string[] args)
    {
        EqualityScale<int> scale = new(5, 6);

        Console.WriteLine(scale.AreEqual());
    }
}
