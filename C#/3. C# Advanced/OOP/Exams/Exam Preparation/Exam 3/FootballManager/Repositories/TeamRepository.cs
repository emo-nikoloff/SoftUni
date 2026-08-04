using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;

namespace FootballManager.Repositories;

public class TeamRepository : IRepository<ITeam>
{
    private List<ITeam> models;

    private int capacity = 10;

    public TeamRepository()
    {
        models = new();
    }

    public IReadOnlyCollection<ITeam> Models => models;

    public int Capacity => capacity;

    public void Add(ITeam model)
    {
        if (Models.Count < Capacity)
        {
            models.Add(model);
        }
    }

    public bool Remove(string name)
    {
        ITeam? team = models.FirstOrDefault(t => t.Name == name)!;
        return models.Remove(team);
    }

    public bool Exists(string name) => models.Any(t => t.Name == name);

    public ITeam Get(string name) => models.FirstOrDefault(t => t.Name == name)!;
}
