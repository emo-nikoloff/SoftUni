namespace ShoppingSpree;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Person> people = new();
        List<Product> products = new();

        string[] peopleInfo = Console.ReadLine().Split(new[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);
        string[] productsInfo = Console.ReadLine().Split(new[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            for (int i = 0; i < peopleInfo.Length; i++)
            {
                string name = peopleInfo[i];
                decimal money = decimal.Parse(peopleInfo[++i]);

                Person person = new(name, money);
                people.Add(person);
            }

            for (int i = 0; i < productsInfo.Length; i++)
            {
                string name = productsInfo[i];
                decimal cost = decimal.Parse(productsInfo[++i]);

                Product product = new(name, cost);
                products.Add(product);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputInfo = input.Split(' ');

            string personName = inputInfo[0];
            string productName = inputInfo[1];

            Person person = people.FirstOrDefault(p => p.Name == personName);
            Product product = products.FirstOrDefault(p => p.Name == productName);

            if (person != null && product != null)
            {
                Console.WriteLine(person.Purchase(product));
            }
        }
        people.ForEach(Console.WriteLine);
    }
}
