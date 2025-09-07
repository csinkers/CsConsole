namespace CsConsole;

/// <summary>
/// Base interface for console commands that execute synchronously
/// </summary>
public interface ISyncCommand : ICommand
{
    /// <summary>
    /// Invoke the command with the given arguments and output interface
    /// </summary>
    void Invoke(ArgumentSource args, IConsoleOutput o);
}

/// <summary>
/// Base interface for console commands that execute synchronously and maintain state
/// </summary>
/// <typeparam name="TState">The type of the state object</typeparam>
public interface ISyncCommand<in TState> : ICommand
    where TState : ICommandState
{
    /// <summary>
    /// Invoke the command with the given arguments, output interface, and state object
    /// </summary>
    void Invoke(ArgumentSource args, IConsoleOutput o, TState state);
}
