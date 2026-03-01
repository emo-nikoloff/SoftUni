using BorderControl.Models.Interfaces;

namespace BorderControl.Models;

public class Citizen : IIdentifiable
{
    public Citizen(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }

    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
}
