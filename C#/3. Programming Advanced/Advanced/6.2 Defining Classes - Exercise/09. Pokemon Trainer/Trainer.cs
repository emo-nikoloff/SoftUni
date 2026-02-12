namespace _09._Pokemon_Trainer;

public class Trainer
{
    public Trainer(string name)
    {
        Name = name;
        Badges = 0;
        Collection = new();
    }

    public string Name { get; }
    public int Badges { get; set; }
    public List<Pokemon> Collection { get; }

    public override string ToString()
    {
        return $"{Name} {Badges} {Collection.Count}";
    }
}
