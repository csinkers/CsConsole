namespace CsConsole;

public interface ISyncCommand : ICommand
{
    void Invoke(ArgumentSource args, IConsoleOutput o);
}

public interface ISyncCommand<in TState> : ICommand
    where TState : ICommandState
{
    void Invoke(ArgumentSource args, IConsoleOutput o, TState state);
}
