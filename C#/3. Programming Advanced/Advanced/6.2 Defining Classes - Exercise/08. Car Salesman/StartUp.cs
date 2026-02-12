namespace _08._Car_Salesman;

public class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        List<Engine> engines = new();
        for (int i = 1; i <= count; i++)
        {
            string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = info[0];
            int power = int.Parse(info[1]);
            int? displacement = null;
            string efficiency = null;

            if (info.Length == 3)
            {
                if (int.TryParse(info[2], out int value))
                {
                    displacement = value;
                }
                else
                {
                    efficiency = info[2];
                }
            }
            else if (info.Length == 4)
            {
                displacement = int.Parse(info[2]);
                efficiency = info[3];
            }

            Engine engine = new(model, power, displacement, efficiency);
            engines.Add(engine);
        }

        count = int.Parse(Console.ReadLine());

        List<Car> cars = new();
        for (int i = 1; i <= count; i++)
        {
            string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = info[0];
            string engineModel = info[1];
            int? weight = null;
            string color = null;

            if (info.Length == 3)
            {
                if (int.TryParse(info[2], out int value))
                {
                    weight = value;
                }
                else
                {
                    color = info[2];
                }
            }
            else if (info.Length == 4)
            {
                weight = int.Parse(info[2]);
                color = info[3];
            }

            Engine engine = engines.Single(e => e.Model == engineModel);
            Car car = new(model, engine, weight, color);
            cars.Add(car);
        }

        cars.ForEach(Console.WriteLine);
    }
}
