namespace CsConsole;

/// <summary>
/// A simple asynchronous console command class that accepts a delegate for execution.
/// </summary>
public class AsyncCommand : IAsyncCommand
{
    readonly AsyncCommandMethod _func;

    /// <summary>
    /// Create a new asynchronous command with the given name and execution function.
    /// </summary>
    public AsyncCommand(string name, AsyncCommandMethod func)
    {
        _func = func;
        Names = [name];
    }

    /// <summary>
    /// Create a new asynchronous command with the given name and execution function.
    /// </summary>
    public AsyncCommand(string[] names, AsyncCommandMethod func)
    {
        _func = func;
        Names = names;
    }

    /// <inheritdoc />
    public Task InvokeAsync(ArgumentSource args, IConsoleOutput o, CancellationToken ct) =>
        _func(args, o, ct);

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
/// A simple asynchronous console command class that accepts a delegate for execution that uses a state object.
/// </summary>
public class AsyncCommand<T> : IAsyncCommand<T>
    where T : ICommandState
{
    readonly AsyncCommandMethod<T> _func;

    /// <summary>
    /// Create a new asynchronous command with the given name and execution function.
    /// </summary>
    public AsyncCommand(string name, AsyncCommandMethod<T> func)
    {
        _func = func;
        Names = [name];
    }

    /// <summary>
    /// Create a new asynchronous command with the given name and execution function.
    /// </summary>
    public AsyncCommand(string[] names, AsyncCommandMethod<T> func)
    {
        _func = func;
        Names = names;
    }

    /// <inheritdoc />
    public Task InvokeAsync(ArgumentSource args, IConsoleOutput o, T state, CancellationToken ct) =>
        _func(args, o, state, ct);

    /// <inheritdoc />
    public string[] Names { get; }

    /// <inheritdoc />
    public string? Description { get; init; }

    /// <inheritdoc />
    public string? ShortDescription { get; init; }

    /// <inheritdoc />
    public string? Usage { get; init; }
}
