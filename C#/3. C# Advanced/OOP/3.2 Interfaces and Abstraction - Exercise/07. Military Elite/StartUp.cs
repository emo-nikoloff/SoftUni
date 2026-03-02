using MilitaryElite.Enums;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite;

public class StartUp
{
    private static Dictionary<int, ISoldier> soldiers = new();

    static void Main(string[] args)
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string rank = inputInfo[0];
            int id = int.Parse(inputInfo[1]);

            ISoldier soldier = null;

            try
            {
                switch (rank)
                {
                    case "Private":
                        soldier = GetPrivate(inputInfo);
                        break;
                    case "LieutenantGeneral":
                        soldier = GetLieutenantGeneral(inputInfo);
                        break;
                    case "Engineer":
                        soldier = GetEngineer(inputInfo);
                        break;
                    case "Commando":
                        soldier = GetCommando(inputInfo);
                        break;
                    case "Spy":
                        soldier = GetSpy(inputInfo);
                        break;
                }

                if (soldier != null)
                {
                    soldiers.Add(id, soldier);
                    Console.WriteLine(soldier);
                }
            }
            catch (Exception)
            {
            }
        }
    }

    private static ISoldier GetPrivate(string[] data)
    {
        int id = int.Parse(data[1]);
        string firstName = data[2];
        string lastName = data[3];
        decimal salary = decimal.Parse(data[4]);

        return new Private(id, firstName, lastName, salary);
    }

    private static ISoldier GetLieutenantGeneral(string[] data)
    {
        int id = int.Parse(data[1]);
        string firstName = data[2];
        string lastName = data[3];
        decimal salary = decimal.Parse(data[4]);

        List<IPrivate> privates = new();

        for (int i = 5; i < data.Length; i++)
        {
            int soldierId = int.Parse(data[i]);

            if (soldiers.ContainsKey(soldierId))
            {
                IPrivate soldier = (IPrivate)soldiers[soldierId];
                privates.Add(soldier);
            }
        }

        return new LieutenantGeneral(id, firstName, lastName, salary, privates);
    }

    private static ISoldier GetEngineer(string[] data)
    {
        int id = int.Parse(data[1]);
        string firstName = data[2];
        string lastName = data[3];
        decimal salary = decimal.Parse(data[4]);

        bool isValidCorps = Enum.TryParse(data[5], out Corps corps);

        if (!isValidCorps)
        {
            throw new Exception();
        }

        List<IRepair> repairs = new();

        for (int i = 6; i < data.Length; i += 2)
        {
            string partName = data[i];
            int hoursWorked = int.Parse(data[i + 1]);

            IRepair repair = new Repair(partName, hoursWorked);

            repairs.Add(repair);
        }

        return new Engineer(id, firstName, lastName, salary, corps, repairs);
    }

    private static ISoldier GetCommando(string[] data)
    {
        int id = int.Parse(data[1]);
        string firstName = data[2];
        string lastName = data[3];
        decimal salary = decimal.Parse(data[4]);

        bool isValidCorps = Enum.TryParse(data[5], out Corps corps);

        if (!isValidCorps)
        {
            throw new Exception();
        }

        List<IMission> missions = new();

        for (int i = 6; i < data.Length; i += 2)
        {
            string missionName = data[i];
            string missionState = data[i + 1];

            bool isValidMissionState = Enum.TryParse(missionState, out State state);

            if (!isValidMissionState)
            {
                continue;
            }

            IMission mission = new Mission(missionName, state);

            missions.Add(mission);
        }

        return new Commando(id, firstName, lastName, salary, corps, missions);
    }

    private static ISoldier GetSpy(string[] data)
    {
        int id = int.Parse(data[1]);
        string firstName = data[2];
        string lastName = data[3];
        int codeNumber = int.Parse(data[4]);

        return new Spy(id, firstName, lastName, codeNumber);
    }
}
