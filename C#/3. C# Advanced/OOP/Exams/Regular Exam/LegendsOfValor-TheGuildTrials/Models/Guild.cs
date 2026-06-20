using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;

namespace LegendsOfValor_TheGuildTrials.Models;

public class Guild : IGuild
{
    private string name;
    private int wealth;
    private readonly List<string> legion;
    private bool isFallen;

    public Guild(string name)
    {
        Name = name;
        Wealth = 5000;
        legion = new();
        IsFallen = false;
    }

    public string Name
    {
        get => name;
        private set
        {
            string[] validGuildNames = { "WarriorGuild", "SorcererGuild", "ShadowGuild" };
            if (!validGuildNames.Contains(value))
            {
                throw new ArgumentException(ErrorMessages.InvalidGuildName);
            }
            name = value;
        }
    }

    public int Wealth
    {
        get => wealth;
        private set => wealth = value;
    }

    public IReadOnlyCollection<string> Legion => legion;

    public bool IsFallen
    {
        get => isFallen;
        private set => isFallen = value;
    }

    public void LoseWar()
    {
        IsFallen = true;
        Wealth = 0;
    }

    public void RecruitHero(IHero hero)
    {
        if (!IsFallen)
        {
            Wealth -= 500;
            legion.Add(hero.RuneMark);
        }
    }

    public void TrainLegion(ICollection<IHero> heroesToTrain)
    {
        if (!IsFallen)
        {
            foreach (IHero hero in heroesToTrain)
            {
                Wealth -= 200;
                hero.Train();
            }
        }
    }

    public void WinWar(int goldAmount)
    {
        if (!IsFallen)
        {
            Wealth += goldAmount;
        }
    }
}
