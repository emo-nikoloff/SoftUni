namespace _04._Product_Shop;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, decimal>> supermarkets = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Revision")
        {
            string[] inputTokens = input.Split(", ");
            string supermarket = inputTokens[0];
            string product = inputTokens[1];
            decimal productPrice = decimal.Parse(inputTokens[2]);

            if (!supermarkets.ContainsKey(supermarket))
            {
                supermarkets.Add(supermarket, new());
            }
            supermarkets[supermarket].Add(product, productPrice);
        }

        foreach ((string supermarket, Dictionary<string, decimal> products) in supermarkets.OrderBy(s => s.Key))
        {
            Console.WriteLine($"{supermarket}->");
            foreach ((string product, decimal price) in products)
            {
                Console.WriteLine($"Product: {product}, Price: {price:0.##}");
            }
        }
    }
}
