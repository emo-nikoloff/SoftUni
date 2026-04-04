using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;

namespace LegendsOfValor_TheGuildTrials.Repositories;

public class GuildRepository : IRepository<Guild>
{
    private readonly List<Guild> guilds = new();

    public GuildRepository()
    {
        guilds = new();
    }

    public void AddModel(Guild entity) => guilds.Add(entity);
    public IReadOnlyCollection<Guild> GetAll() => guilds;
    public Guild GetModel(string guildName) => guilds.FirstOrDefault(g => g.Name == guildName);
}
