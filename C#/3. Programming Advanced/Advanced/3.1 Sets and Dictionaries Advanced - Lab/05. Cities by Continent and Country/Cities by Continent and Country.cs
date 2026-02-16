/*Create a program that reads continents, countries and their cities put them in a nested dictionary and prints them.*/
namespace _05._Cities_by_Continent_and_Country;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, List<string>>> continents = new();
        int continentsNumber = int.Parse(Console.ReadLine());

        for (int i = 1; i <= continentsNumber; i++)
        {
            string[] input = Console.ReadLine().Split();
            string continent = input[0];
            string country = input[1];
            string city = input[2];

            if (!continents.ContainsKey(continent))
            {
                continents.Add(continent, new());
            }
            if (!continents[continent].ContainsKey(country))
            {
                continents[continent].Add(country, new());
            }
            continents[continent][country].Add(city);
        }

        foreach ((string continent, Dictionary<string, List<string>> countries) in continents)
        {
            Console.WriteLine($"{continent}:");
            foreach ((string country, List<string> cities) in countries)
            {
                Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");
            }
        }
    }
}
