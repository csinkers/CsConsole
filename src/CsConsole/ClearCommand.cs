namespace CsConsole;

public class ClearCommand : IStatelessSyncCommand
{
    public string[] Names => ["clear", "cls"];
    public string Description => "Clears the screen";
    public string? ShortDescription => null;
    public string? Usage => null;
    public void Invoke(ArgumentSource args, IConsoleOutput o) => o.Clear();
}