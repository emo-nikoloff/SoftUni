/*Our favorite super-spy action hero Sam is back from his mission from the previous exam and he has finally found some time to go on a holiday. He is taking his wife somewhere nice and they're
going to have a really good time, but first, they have to get there. Even on his holiday trip, Sam is still going to run into some problems and the first one is, of course, getting to the airport.
Right now, he is stuck in a traffic jam at a very active crossroad where a lot of accidents happen. Your job is to keep track of traffic at the crossroads and report whether a crash happened or
everyone passed the crossroads safely and our hero is one step closer to a much-desired vacation. The road Sam is on has a single lane where cars queue up until the light goes green. When it does,
they start passing one by one during the green light and the free window before the intersecting road's light goes green. During one second only one part of a car (a single character) passes the
crossroads. If a car is still at the crossroads when the free window ends, it will get hit at the first character that is still in the crossroads.*/
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
