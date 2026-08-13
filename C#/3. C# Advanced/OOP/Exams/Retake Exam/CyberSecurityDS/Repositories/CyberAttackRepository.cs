using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;

namespace CyberSecurityDS.Repositories;

public class CyberAttackRepository : IRepository<ICyberAttack>
{
    private List<ICyberAttack> models;

    public CyberAttackRepository()
    {
        models = new();
    }

    public IReadOnlyCollection<ICyberAttack> Models => models;

    public void AddNew(ICyberAttack model) => models.Add(model);

    public ICyberAttack GetByName(string name) => models.FirstOrDefault(ca => ca.AttackName == name)!;

    public bool Exists(string name) => models.Any(ca => ca.AttackName == name);
}
