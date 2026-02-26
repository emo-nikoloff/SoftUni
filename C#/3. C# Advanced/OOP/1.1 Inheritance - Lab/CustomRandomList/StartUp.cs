namespace CustomRandomList;

public class StartUp
{
    static void Main(string[] args)
    {
        RandomList randomList = new() { "Yordan", "Kaloyan", "Yosif", "Naum" };
        Console.WriteLine(randomList.RandomString());
    }
}
