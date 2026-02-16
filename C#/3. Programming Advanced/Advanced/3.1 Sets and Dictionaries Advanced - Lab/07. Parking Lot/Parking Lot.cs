/*Create a program that:
· Records a car number for every car that enters the parking lot.
· Removes a car number when the car leaves the parking lot.
The input will be a string in the format: "direction, carNumber". You will be receiving commands until the "END" command is given.
Print the car numbers of the cars, which are still in the parking lot.*/
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
