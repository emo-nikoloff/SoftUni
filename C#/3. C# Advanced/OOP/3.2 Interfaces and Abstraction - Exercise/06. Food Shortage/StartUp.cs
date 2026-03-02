using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IBuyer> buyers = new();
        int peopleNumber = int.Parse(Console.ReadLine());

        for (int i = 1; i <= peopleNumber; i++)
        {
            string[] buyerInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = buyerInfo[0];
            int age = int.Parse(buyerInfo[1]);

            IBuyer buyer = null;

            if (buyerInfo.Length == 3)
            {
                string group = buyerInfo[2];

                buyer = new Rebel(name, age, group);
            }
            else if (buyerInfo.Length == 4)
            {
                string id = buyerInfo[2];
                string birthdate = buyerInfo[3];

                buyer = new Citizen(name, age, id, birthdate);
            }

            buyers.Add(buyer);
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            IBuyer buyer = buyers.FirstOrDefault(b => b.Name == input);
            if (buyer != null)
            {
                buyer.BuyFood();
            }
        }
        Console.WriteLine(buyers.Sum(b => b.Food));
    }
}
