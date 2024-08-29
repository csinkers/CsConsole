namespace CsConsole;

public class AsyncCommand(string name, AsyncCommandMethod func) : IAsyncCommand
{
    public Task InvokeAsync(ArgumentSource args, IConsoleOutput o, CancellationToken ct) =>
        func(args, o, ct);

    public string[] Names { get; } = [name];
    public string? Description { get; init; }
    public string? ShortDescription { get; init; }
    public string? Usage { get; init; }
}

public class AsyncCommand<T>(string name, AsyncCommandMethod<T> func) : IAsyncCommand<T>
    where T : ICommandState
{
    public Task InvokeAsync(ArgumentSource args, IConsoleOutput o, T state, CancellationToken ct) =>
        func(args, o, state, ct);

    public string[] Names { get; } = [name];
    public string? Description { get; init; }
    public string? ShortDescription { get; init; }
    public string? Usage { get; init; }
}
