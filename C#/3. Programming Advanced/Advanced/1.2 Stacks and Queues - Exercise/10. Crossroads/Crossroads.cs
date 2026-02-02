namespace _10._Crossroads;

class Program
{
    static void Main(string[] args)
    {
        int greenLightDuration = int.Parse(Console.ReadLine());
        int freeWindow = int.Parse(Console.ReadLine());

        Queue<string> cars = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            if (input != "green")
            {
                cars.Enqueue(input);
            }
        }
    }
}
