namespace _06._Wardrobe;

class Program
{
    static void Main(string[] args)
    {
        int colours = int.Parse(Console.ReadLine());

        Dictionary<string, Dictionary<string, int>> clothes = new();
        for (int i = 1; i <= colours; i++)
        {
            string[] input = Console.ReadLine().Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries);
            string colour = input[0];

            if (!clothes.ContainsKey(colour))
            {
                clothes.Add(colour, new());
            }
            foreach (string wear in input.Skip(1))
            {
                if (!clothes[colour].ContainsKey(wear))
                {
                    clothes[colour].Add(wear, 1);
                    continue;
                }
                clothes[colour][wear]++;
            }
        }

        string[] searchWear = Console.ReadLine().Split();
        string wearColour = searchWear[0];
        string wearType = searchWear[1];

        foreach ((string colour, Dictionary<string, int> clothing) in clothes)
        {
            Console.WriteLine($"{colour} clothes:");
            foreach ((string wear, int count) in clothing)
            {
                string suffix = string.Empty;
                if (colour == wearColour && wear == wearType)
                {
                    suffix = " (found!)";
                }
                Console.WriteLine($"* {wear} - {count}{suffix}");
            }
        }
    }
}
