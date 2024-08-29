namespace CsConsole;

public class HelpCommand(ICommandParser parser) : ISyncCommand
{
    public string[] Names => ["help", "?", "h"];
    public string Description => "When given a command line, shows detailed info on the command. When run without an argument, lists all available commands.";
    public string? ShortDescription => null;
    public string Usage => "[command]";

    public void Invoke(ArgumentSource args, IConsoleOutput o)
    {
        if (args.Remaining == 0)
            ListCommands(o);
        else
            DescribeCommand(args.Arg("command"), o);
    }

    void DescribeCommand(string name, IConsoleOutput o)
    {
        if (!parser.TryGetCommand(name, out var command) || command == null)
            throw new ConsoleCommandException($"Unknown command \"{name}\"");

        o.WriteLine($"{command.Names[0]} {command.Usage}");

        var desc = command.Description ?? command.ShortDescription;
        if (desc != null)
        {
            o.WriteLine();
            o.WriteLine();
        }
    }

    void ListCommands(IConsoleOutput o)
    {
        var commands = parser.Commands.OrderBy(x => x.Names[0]).Select(x => (Name: x.Names[0], Command: x)).ToList();
        int maxLen = commands.Max(x => x.Name.Length);

        foreach (var (name, command) in commands)
        {
            string aliases = "";
            if (command.Names.Length > 1)
                aliases = $" [{string.Join(", ", command.Names.Skip(1))}]";

            o.WriteLine($"{name.PadRight(maxLen)}: {command.ShortDescription ?? command.Description}{aliases}");
        }
    }
}