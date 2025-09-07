namespace CsConsole;

/// <summary>
/// The base interface for console commands
/// </summary>
public interface ICommand
{
    /// <summary>
    /// The names that can be used to invoke this command
    /// </summary>
    string[] Names { get; }

    /// <summary>
    /// A description of the command, used in help text
    /// </summary>
    string? Description { get; }

    /// <summary>
    /// A short description of the command, used in summary help text
    /// </summary>
    string? ShortDescription { get; }

    /// <summary>
    /// Details on how to use the command, used in help text
    /// </summary>
    string? Usage { get; }
}
