namespace CsConsole;

/// <summary>
/// The base interface for command parser loop state objects
/// </summary>
public interface ICommandState
{
    /// <summary>
    /// When this is set to true, the command loop should exit
    /// </summary>
    bool Done { get; }
}
