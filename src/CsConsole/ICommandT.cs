namespace CsConsole;

public interface ICommand<in TState> : ICommand where TState : ICommandState
{
    Task InvokeAsync(ArgumentSource args, IConsoleOutput o, TState state, CancellationToken ct);
}