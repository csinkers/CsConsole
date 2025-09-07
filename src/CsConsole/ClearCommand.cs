namespace CsConsole;

/// <summary>
/// A command that clears the console output
/// </summary>
public class ClearCommand : ISyncCommand
{
    /// <inheritdoc />
    public string[] Names => ["clear", "cls"];

    /// <inheritdoc />
    public string Description => "Clears the screen";

    /// <inheritdoc />
    public string? ShortDescription => null;

    /// <inheritdoc />
    public string? Usage => null;

    /// <inheritdoc />
    public void Invoke(ArgumentSource args, IConsoleOutput o) => o.Clear();
}
