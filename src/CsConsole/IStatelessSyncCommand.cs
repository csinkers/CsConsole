namespace CsConsole;

public interface IStatelessSyncCommand : ICommand
{
    void Invoke(ArgumentSource args, IConsoleOutput o);
}