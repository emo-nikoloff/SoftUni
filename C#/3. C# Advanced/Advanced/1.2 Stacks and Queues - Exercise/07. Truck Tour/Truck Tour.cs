/*Let’s suppose there is a circular route for lorries. There are N petrol pumps on that toute. Petrol pumps are numbered 0 to (N−1) (both inclusive). You will receive information (array),
corresponding to each of the petrol pumps: [0] the amount of petrol (in litres) that particular petrol pump will give, and [1] the distance(in kilometers) from the current petrol pump to the next
petrol pump. You have a tank of infinite capacity carrying no petrol. Your task is to figure out, which is the first possible petrol pump, from which the lorry will be able to complete the route.
Consider that the lorry will stop at each of the petrol pumps. The lorry will move one kilometer for each liter of petrol.*/
namespace _07._Truck_Tour;

class Program
{
    static void Main(string[] args)
    {
        int petrolPumps = int.Parse(Console.ReadLine());
        Queue<int[]> pumps = new();
        for (int i = 0; i < petrolPumps; i++)
        {
            int[] pump = Console.ReadLine().Split().Select(int.Parse).ToArray();
            pumps.Enqueue(pump);
        }

        int validPumpIndex = -1;

        for (int i = 0; i < petrolPumps; i++)
        {
            bool canFinishRoute = true;
            int currentFuel = 0;

            foreach (int[] pump in pumps)
            {
                int fuel = pump[0];
                int distance = pump[1];
                currentFuel += fuel - distance;
                if (currentFuel < 0)
                {
                    canFinishRoute = false;
                    break;
                }
            }

            if (canFinishRoute)
            {
                validPumpIndex = i;
                break;
            }

            pumps.Enqueue(pumps.Dequeue());
        }

        Console.WriteLine(validPumpIndex);
    }
}
