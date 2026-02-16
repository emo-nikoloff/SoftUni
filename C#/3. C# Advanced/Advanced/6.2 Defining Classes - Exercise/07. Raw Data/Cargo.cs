namespace _07._Raw_Data;

public class Cargo
{
    public Cargo(string type, int weight)
    {
        Type = type;
        Weight = weight;
    }

    public string Type { get; }
    public int Weight { get; }
}
