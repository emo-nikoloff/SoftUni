using static CyberSecurityDS.Utilities.Messages.ExceptionMessages;

namespace CyberSecurityDS.Models.CyberAttacks;

public class PhishingAttack : CyberAttack
{
    private string targetMail = null!;

    public PhishingAttack(string attackName, int severityLevel, string targetMail)
        : base(attackName, severityLevel)
    {
        TargetMail = targetMail;
    }

    public string TargetMail
    {
        get => targetMail;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(TargetMailRequired);
            }
            targetMail = value;
        }
    }

    public override string ToString() => $"Attack: {AttackName}, Severity: {SeverityLevel} (Target Mail: {TargetMail})";
}
