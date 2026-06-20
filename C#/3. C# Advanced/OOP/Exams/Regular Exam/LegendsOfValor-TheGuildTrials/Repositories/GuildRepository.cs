using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;

namespace LegendsOfValor_TheGuildTrials.Repositories;

public class GuildRepository : IRepository<IGuild>
{
    private readonly List<IGuild> guilds = new();

    public GuildRepository()
    {
        guilds = new();
    }

    public void AddModel(IGuild entity) => guilds.Add(entity);
    public IReadOnlyCollection<IGuild> GetAll() => guilds;
    public IGuild GetModel(string guildName) => guilds.FirstOrDefault(g => g.Name == guildName);
}
