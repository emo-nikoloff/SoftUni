using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;

namespace LegendsOfValor_TheGuildTrials.Repositories;

public class HeroRepository : IRepository<IHero>
{
    private readonly List<IHero> heroes;

    public HeroRepository()
    {
        heroes = new();
    }

    public void AddModel(IHero entity) => heroes.Add(entity);
    public IReadOnlyCollection<IHero> GetAll() => heroes;
    public IHero GetModel(string runeMark) => heroes.FirstOrDefault(h => h.RuneMark == runeMark);
}
