namespace _09._Pokemon_Trainer;

public class Pokemon
{
    public Pokemon(string name, string element, int health)
    {
        Name = name;
        Element = element;
        Health = health;
    }

    public string Name { get; }
    public string Element { get; }
    public int Health { get; set; }
}
