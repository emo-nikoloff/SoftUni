using CyberSecurityDS.Models.Contracts;
using static CyberSecurityDS.Utilities.Messages.ExceptionMessages;

namespace CyberSecurityDS.Models;

public abstract class CyberAttack : ICyberAttack
{
    private string attackName = null!;

    private int severityLevel;

    protected CyberAttack(string attackName, int severityLevel)
    {
        AttackName = attackName;
        SeverityLevel = severityLevel;
    }

    public string AttackName
    {
        get => attackName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(CyberAttackNameRequired);
            }
            attackName = value;
        }
    }

    public int SeverityLevel
    {
        get => severityLevel;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(SeverityLevelNegative);
            }

            if (value == 0)
            {
                severityLevel = 1;
            }
            else if (value > 10)
            {
                severityLevel = 10;
            }
            else
            {
                severityLevel = value;
            }
        }
    }

    public bool Status { get; private set; }

    public void MarkAsMitigated() => Status = true;
}
