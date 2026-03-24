namespace Stealer;

public class StartUp
{
    static void Main(string[] args)
    {
        Spy spy = new();
        string result;

        result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
        Console.WriteLine(result);
        Console.WriteLine();

        result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
        Console.WriteLine(result);
        Console.WriteLine();

        result = spy.RevealPrivateMethods("Stealer.Hacker");
        Console.WriteLine(result);
        Console.WriteLine();

        result = spy.CollectGetterAndSetters("Stealer.Hacker");
        Console.WriteLine(result);
        Console.WriteLine();
    }
}
