namespace CsConsole;

/// <summary>
/// A simple asynchronous console command class that accepts a delegate for execution.
/// </summary>
public class AsyncCommand(string name, AsyncCommandMethod func) : IAsyncCommand
{
    /// <inheritdoc />
    public Task InvokeAsync(ArgumentSource args, IConsoleOutput o, CancellationToken ct) =>
        func(args, o, ct);

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
/// A simple asynchronous console command class that accepts a delegate for execution that uses a state object.
/// </summary>
public class AsyncCommand<T>(string name, AsyncCommandMethod<T> func) : IAsyncCommand<T>
    where T : ICommandState
{
    /// <inheritdoc />
    public Task InvokeAsync(ArgumentSource args, IConsoleOutput o, T state, CancellationToken ct) =>
        func(args, o, state, ct);

    /// <inheritdoc />
    public string[] Names { get; } = [name];

    /// <inheritdoc />
    public string? Description { get; init; }

    /// <inheritdoc />
    public string? ShortDescription { get; init; }

    /// <inheritdoc />
    public string? Usage { get; init; }
}
