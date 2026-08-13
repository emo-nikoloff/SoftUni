using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;

namespace CyberSecurityDS.Repositories;

public class DefensiveSoftwareRepository : IRepository<IDefensiveSoftware>
{
    private List<IDefensiveSoftware> models;

    public DefensiveSoftwareRepository()
    {
        models = new();
    }

    public IReadOnlyCollection<IDefensiveSoftware> Models => models;

    public void AddNew(IDefensiveSoftware model) => models.Add(model);

    public IDefensiveSoftware GetByName(string name) => models.FirstOrDefault(ds => ds.Name == name)!;

    public bool Exists(string name) => models.Any(ds => ds.Name == name);
}
