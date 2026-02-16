/*Create a program that prints information about food shops in Sofia and the products they store. Until the "Revision" command is received, you will be receiving input in the format:
"{shop}, {product}, {price}". Keep in mind that if you receive a shop you already have received, you must collect its product information.
Your output must be ordered by shop name and must be in the format:
"{shop}->
Product: {product}, Price: {price}"
Note: The price should not be rounded or formatted.*/
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
