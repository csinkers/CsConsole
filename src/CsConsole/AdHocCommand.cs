namespace CsConsole;

public class AdHocCommand<T>(string name, CommandMethod<T> func)
    : ICommand<T>
    where T : ICommandState
{
    public Task InvokeAsync(ArgumentSource args, IConsoleOutput o, T state, CancellationToken ct) => func(args, o, state, ct);
    public string[] Names { get; } = [name];
    public string? Description { get; init; }
    public string? ShortDescription { get; init; }
    public string? Usage { get; init; }
}