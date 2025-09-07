namespace CsConsole;

/// <summary>
/// Interface for a command parser that maintains a collection of commands and can look them up by name
/// </summary>
public interface ICommandParser
{
    /// <summary>
    /// The current set of registered commands
    /// </summary>
    IEnumerable<ICommand> Commands { get; }

    /// <summary>
    /// Attempts to look up a command by name
    /// </summary>
    /// <param name="name">The command name to find</param>
    /// <param name="command">The command, or null if no matching command was found.</param>
    /// <returns>True if a matching command was found.</returns>
    bool TryGetCommand(string name, out ICommand? command);
}
