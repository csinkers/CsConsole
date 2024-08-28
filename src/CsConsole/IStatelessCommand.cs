namespace CsConsole;

public interface IStatelessCommand : ICommand
{
    Task InvokeAsync(ArgumentSource args, IConsoleOutput o, CancellationToken ct);
}