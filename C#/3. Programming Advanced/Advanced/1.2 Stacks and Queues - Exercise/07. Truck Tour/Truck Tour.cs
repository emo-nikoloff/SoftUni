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
