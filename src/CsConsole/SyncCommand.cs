namespace CsConsole;

/// <summary>
/// A simple synchronous console command class that accepts a delegate for execution.
/// </summary>
public class SyncCommand : ISyncCommand
{
    readonly SyncCommandMethod _func;

    /// <summary>
    /// Create a new synchronous command with the given name and execution function.
    /// </summary>
    public SyncCommand(string name, SyncCommandMethod func)
    {
        _func = func;
        Names = [name];
    }

    /// <summary>
    /// Create a new synchronous command with the given names and execution function.
    /// </summary>
    public SyncCommand(string[] names, SyncCommandMethod func)
    {
        _func = func;
        Names = names;
    }

    /// <inheritdoc />
    public void Invoke(ArgumentSource args, IConsoleOutput o) => _func(args, o);

    /// <inheritdoc />
    public string[] Names { get; }

    /// <inheritdoc />
    public string? Description { get; init; }

    /// <inheritdoc />
    public string? ShortDescription { get; init; }

    /// <inheritdoc />
    public string? Usage { get; init; }
}

/// <summary>
/// A simple synchronous console command class that accepts a delegate for execution that uses a state object.
/// </summary>
public class SyncCommand<T> : ISyncCommand<T>
    where T : ICommandState
{
    readonly SyncCommandMethod<T> _func;

    /// <summary>
    /// Create a new synchronous command with the given names and execution function.
    /// </summary>
    public SyncCommand(string name, SyncCommandMethod<T> func)
    {
        _func = func;
        Names = [name];
    }

    /// <summary>
    /// Create a new synchronous command with the given names and execution function.
    /// </summary>
    public SyncCommand(string[] names, SyncCommandMethod<T> func)
    {
        _func = func;
        Names = names;
    }

    /// <inheritdoc />
    public void Invoke(ArgumentSource args, IConsoleOutput o, T state) => _func(args, o, state);

    /// <inheritdoc />
    public string[] Names { get; }

    /// <inheritdoc />
    public string? Description { get; init; }

    /// <inheritdoc />
    public string? ShortDescription { get; init; }

    /// <inheritdoc />
    public string? Usage { get; init; }
}
