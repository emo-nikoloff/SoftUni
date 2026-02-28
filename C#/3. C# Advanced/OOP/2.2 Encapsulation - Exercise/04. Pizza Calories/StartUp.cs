using PizzaCalories.Models;

namespace PizzaCalories;

public class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            string[] pizzaInfo = Console.ReadLine().Split(' ').Skip(1).ToArray();
            string pizzaName = pizzaInfo[0];
            Pizza pizza = new(pizzaName);

            string[] doughInfo = Console.ReadLine().Split(' ').Skip(1).ToArray();
            string flourType = doughInfo[1];
            string bakingTechnique = doughInfo[2];
            double doughWeight = double.Parse(doughInfo[3]);
            Dough dough = new(flourType, bakingTechnique, doughWeight);

            pizza.Dough = dough;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] toppingInfo = input.Split(' ').Skip(1).ToArray();
                string toppingType = toppingInfo[0];
                double toppingWeight = double.Parse(toppingInfo[1]);

                Topping topping = new(toppingType, toppingWeight);

                pizza.AddTopping(topping);
            }
            Console.WriteLine(pizza);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
