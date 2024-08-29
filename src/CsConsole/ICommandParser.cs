namespace CsConsole;

public interface ICommandParser
{
    IEnumerable<ICommand> Commands { get; }
    bool TryGetCommand(string name, out ICommand? command);
}
