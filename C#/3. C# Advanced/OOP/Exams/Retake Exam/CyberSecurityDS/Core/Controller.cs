using System.Text;
using CyberSecurityDS.Core.Contracts;
using CyberSecurityDS.Models;
using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Models.CyberAttacks;
using CyberSecurityDS.Models.DefensiveSoftwares;
using static CyberSecurityDS.Utilities.Messages.OutputMessages;

namespace CyberSecurityDS.Core;

public class Controller : IController
{
    private ISystemManager systemManager;

    public Controller()
    {
        systemManager = new SystemManager();
    }

    public string AddCyberAttack(string attackType, string attackName, int severityLevel, string extraParam)
    {
        if (attackType is not ("PhishingAttack" or "MalwareAttack"))
        {
            return string.Format(TypeInvalid, attackType);
        }

        if (systemManager.CyberAttacks.Exists(attackName))
        {
            return string.Format(EntryAlreadyExists, attackName);
        }

        ICyberAttack cyberAttack = attackType switch
        {
            "PhishingAttack" => new PhishingAttack(attackName, severityLevel, extraParam),
            "MalwareAttack" => new MalwareAttack(attackName, severityLevel, extraParam),
            _ => null!
        };

        systemManager.CyberAttacks.AddNew(cyberAttack);

        return string.Format(EntryAddedSuccessfully, attackType, attackName);
    }

    public string AddDefensiveSoftware(string softwareType, string softwareName, int effectiveness)
    {
        if (softwareType is not ("Firewall" or "Antivirus"))
        {
            return string.Format(TypeInvalid, softwareType);
        }

        if (systemManager.DefensiveSoftwares.Exists(softwareName))
        {
            return string.Format(EntryAlreadyExists, softwareName);
        }

        IDefensiveSoftware defensiveSoftware = softwareType switch
        {
            "Firewall" => new Firewall(softwareName, effectiveness),
            "Antivirus" => new Antivirus(softwareName, effectiveness),
            _ => null!
        };

        systemManager.DefensiveSoftwares.AddNew(defensiveSoftware);

        return string.Format(EntryAddedSuccessfully, softwareType, softwareName);
    }

    public string AssignDefense(string cyberAttackName, string defensiveSoftwareName)
    {
        if (!systemManager.CyberAttacks.Exists(cyberAttackName))
        {
            return string.Format(EntryNotFound, cyberAttackName);
        }

        if (!systemManager.DefensiveSoftwares.Exists(defensiveSoftwareName))
        {
            return string.Format(EntryNotFound, defensiveSoftwareName);
        }

        ICyberAttack cyberAttack = systemManager.CyberAttacks.GetByName(cyberAttackName);
        IDefensiveSoftware defensiveSoftware = systemManager.DefensiveSoftwares.GetByName(defensiveSoftwareName);

        IDefensiveSoftware? cyberAttackAssignedSoftware = systemManager.DefensiveSoftwares.Models
            .FirstOrDefault(ds => ds.AssignedAttacks
            .Contains(cyberAttack.AttackName));
        if (cyberAttackAssignedSoftware != null)
        {
            return string.Format(AttackAlreadyAssigned, cyberAttack.AttackName, cyberAttackAssignedSoftware.Name);
        }

        defensiveSoftware.AssignAttack(cyberAttack.AttackName);

        return string.Format(AttackAssignedSuccessfully, cyberAttack.AttackName, defensiveSoftware.Name);
    }

    public string MitigateAttack(string cyberAttackName)
    {
        if (!systemManager.CyberAttacks.Exists(cyberAttackName))
        {
            return string.Format(EntryNotFound, cyberAttackName);
        }

        ICyberAttack cyberAttack = systemManager.CyberAttacks.GetByName(cyberAttackName);

        if (cyberAttack.Status == true)
        {
            return string.Format(AttackAlreadyMitigated, cyberAttack.AttackName);
        }

        if (!systemManager.DefensiveSoftwares.Models.Any(ds => ds.AssignedAttacks.Contains(cyberAttack.AttackName)))
        {
            return string.Format(AttackNotAssignedYet, cyberAttack.AttackName);
        }

        IDefensiveSoftware defensiveSoftware = systemManager.DefensiveSoftwares.Models.First(ds => ds.AssignedAttacks.Contains(cyberAttack.AttackName));

        if ((defensiveSoftware.GetType() == typeof(Firewall) && cyberAttack.GetType() == typeof(PhishingAttack))
            || (defensiveSoftware.GetType() == typeof(Antivirus) && cyberAttack.GetType() == typeof(MalwareAttack)))
        {
            return string.Format(CannotMitigateDueToCompatibility, defensiveSoftware.GetType().Name, cyberAttack.GetType().Name);
        }

        if (defensiveSoftware.Effectiveness < cyberAttack.SeverityLevel)
        {
            return string.Format(SoftwareNotEffectiveEnough, cyberAttack.AttackName, defensiveSoftware.Name);
        }

        cyberAttack.MarkAsMitigated();

        return string.Format(AttackMitigatedSuccessfully, cyberAttack.AttackName);
    }

    public string GenerateReport()
    {
        StringBuilder result = new();

        result.AppendLine("Security:");
        foreach (IDefensiveSoftware defensiveSoftware in systemManager.DefensiveSoftwares.Models.OrderBy(ds => ds.Name))
        {
            result.AppendLine(defensiveSoftware.ToString());
        }

        result.AppendLine("Threads:");

        result.AppendLine("-Mitigated:");
        foreach (ICyberAttack cyberAttack in systemManager.CyberAttacks.Models.Where(ca => ca.Status == true).OrderBy(ca => ca.AttackName))
        {
            result.AppendLine(cyberAttack.ToString());
        }

        result.AppendLine("-Pending:");
        foreach (ICyberAttack cyberAttack in systemManager.CyberAttacks.Models.Where(ca => ca.Status == false).OrderBy(ca => ca.AttackName))
        {
            result.AppendLine(cyberAttack.ToString());
        }

        return result.ToString().TrimEnd();
    }
}
