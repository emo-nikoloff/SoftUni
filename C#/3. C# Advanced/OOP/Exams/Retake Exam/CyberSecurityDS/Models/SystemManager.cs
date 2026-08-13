using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories;
using CyberSecurityDS.Repositories.Contracts;

namespace CyberSecurityDS.Models;

public class SystemManager : ISystemManager
{
    private CyberAttackRepository cyberAttacks;

    private DefensiveSoftwareRepository defensiveSoftwares;

    public SystemManager()
    {
        cyberAttacks = new CyberAttackRepository();
        defensiveSoftwares = new DefensiveSoftwareRepository();
    }

    public IRepository<ICyberAttack> CyberAttacks => cyberAttacks;

    public IRepository<IDefensiveSoftware> DefensiveSoftwares => defensiveSoftwares;
}
