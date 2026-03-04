namespace _03._Cards;

class Program
{
    static void Main(string[] args)
    {
        List<Card> cards = new();

        string[] cardsInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < cardsInput.Length; i++)
        {
            string[] cardInfo = cardsInput[i].Split();

            try
            {
                Card card = new(cardInfo[0], cardInfo[1]);
                cards.Add(card);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(string.Join(" ", cards));
    }
}

class Card
{
    private static string[] validFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    private static Dictionary<string, string> validSuits = new()
    {
        { "S", "\u2660" },
        { "H", "\u2665" },
        { "D", "\u2666" },
        { "C", "\u2663" },
    };

    public Card(string face, string suit)
    {
        if (!validFaces.Contains(face) || !validSuits.ContainsKey(suit))
        {
            throw new ArgumentException("Invalid card!");
        }

        Face = face;
        Suit = validSuits[suit];
    }

    public string Face { get; }
    public string Suit { get; }

    public override string ToString()
    {
        return $"[{Face}{Suit}]";
    }
}
