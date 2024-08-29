namespace CsConsole;

public interface IAsyncCommand : ICommand
{
    Task InvokeAsync(ArgumentSource args, IConsoleOutput o, CancellationToken ct);
}

public interface IAsyncCommand<in TState> : ICommand
    where TState : ICommandState
{
    Task InvokeAsync(ArgumentSource args, IConsoleOutput o, TState state, CancellationToken ct);
}
