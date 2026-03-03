namespace _10._Crossroads;

class Program
{
    static void Main(string[] args)
    {
        int greenLightDuration = int.Parse(Console.ReadLine());
        int freeWindowDuration = int.Parse(Console.ReadLine());

        Queue<string> cars = new();

        string input = string.Empty;

        int passedCars = 0;
        while ((input = Console.ReadLine()) != "END")
        {
            if (input != "green")
            {
                cars.Enqueue(input);
            }
            else
            {
                bool isGreen = true;
                int time = 0;
                while (cars.Count > 0)
                {
                    if (isGreen)
                    {
                        string car = cars.Dequeue();
                        Queue<char> carSymbols = new(car);

                        while (carSymbols.Count > 0 && greenLightDuration - time > 0)
                        {
                            carSymbols.Dequeue();
                            time++;
                        }

                        if (carSymbols.Count == 0)
                        {
                            passedCars++;
                        }
                        else
                        {
                            for (int i = freeWindowDuration - 1; i >= 0; i--)
                            {
                                carSymbols.Dequeue();
                                if (carSymbols.Count == 0)
                                {
                                    passedCars++;
                                    break;
                                }
                            }

                            isGreen = false;

                            if (carSymbols.Count != 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {carSymbols.Peek()}.");
                                return;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        Console.WriteLine("Everyone is safe.");
        Console.WriteLine($"{passedCars} total cars passed the crossroads.");
    }
}
