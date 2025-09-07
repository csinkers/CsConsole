namespace CsConsole;

/// <summary>
/// Base interface for asynchronous console commands
/// </summary>
public interface IAsyncCommand : ICommand
{
    /// <summary>
    /// Invoke the command with the given arguments and output interface
    /// </summary>
    Task InvokeAsync(ArgumentSource args, IConsoleOutput o, CancellationToken ct);
}

/// <summary>
/// Base interface for asynchronous console commands that maintain state
/// </summary>
public interface IAsyncCommand<in TState> : ICommand
    where TState : ICommandState
{
    /// <summary>
    /// Invoke the command with the given arguments, output interface, and state object
    /// </summary>
    Task InvokeAsync(ArgumentSource args, IConsoleOutput o, TState state, CancellationToken ct);
}
