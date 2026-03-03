namespace _07._Parking_Lot;

class Program
{
    static void Main(string[] args)
    {
        HashSet<string> cars = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputTokens = input.Split(", ");
            string direction = inputTokens[0];
            string carNumber = inputTokens[1];

            switch (direction)
            {
                case "IN":
                    cars.Add(carNumber);
                    break;
                case "OUT":
                    cars.Remove(carNumber);
                    break;
            }
        }

        if (cars.Count == 0)
        {
            Console.WriteLine("Parking Lot is Empty");
            return;
        }

        foreach (string car in cars)
        {
            Console.WriteLine(car);
        }
    }
}
