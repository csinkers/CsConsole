namespace CsConsole;

/// <summary>
/// A simple synchronous console command class that accepts a delegate for execution.
/// </summary>
public class SyncCommand(string name, SyncCommandMethod func) : ISyncCommand
{
    /// <inheritdoc />
    public void Invoke(ArgumentSource args, IConsoleOutput o) => func(args, o);

    /// <inheritdoc />
    public string[] Names { get; } = [name];

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
public class SyncCommand<T>(string name, SyncCommandMethod<T> func) : ISyncCommand<T>
    where T : ICommandState
{
    /// <inheritdoc />
    public void Invoke(ArgumentSource args, IConsoleOutput o, T state) => func(args, o, state);

    /// <inheritdoc />
    public string[] Names { get; } = [name];

    /// <inheritdoc />
    public string? Description { get; init; }

    /// <inheritdoc />
    public string? ShortDescription { get; init; }

    /// <inheritdoc />
    public string? Usage { get; init; }
}
