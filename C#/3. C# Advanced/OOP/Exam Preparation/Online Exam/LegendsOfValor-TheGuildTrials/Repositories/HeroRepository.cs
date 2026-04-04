using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;

namespace LegendsOfValor_TheGuildTrials.Repositories;

public class HeroRepository : IRepository<Hero>
{
    private readonly List<Hero> heroes;

    public HeroRepository()
    {
        heroes = new();
    }

    public void AddModel(Hero entity) => heroes.Add(entity);
    public IReadOnlyCollection<Hero> GetAll() => heroes;
    public Hero GetModel(string runeMark) => heroes.FirstOrDefault(h => h.RuneMark == runeMark);
}
