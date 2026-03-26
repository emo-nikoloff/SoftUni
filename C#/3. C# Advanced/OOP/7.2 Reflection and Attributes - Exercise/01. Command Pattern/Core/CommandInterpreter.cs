using System.Reflection;
using CommandPattern.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core;

public class CommandInterpreter : ICommandInterpreter
{
    public string Read(string args)
    {
        string[] argsInfo = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string commandName = argsInfo[0];
        string[] commandArgs = argsInfo.Skip(1).ToArray();

        Type type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == $"{commandName}Command");
        ICommand command = Activator.CreateInstance(type) as ICommand;

        string result = command.Execute(commandArgs);

        return result;
    }
}
