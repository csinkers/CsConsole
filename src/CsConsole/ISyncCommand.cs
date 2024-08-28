namespace CsConsole;

public interface ISyncCommand<in TState> : ICommand where TState : ICommandState
{
    void Invoke(ArgumentSource args, IConsoleOutput o, TState state);
}