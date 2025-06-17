namespace CsConsole;

public interface IConsoleInput
{
    string ReadLine(CancellationToken ct);
    event EventHandler Interrupt;
}
