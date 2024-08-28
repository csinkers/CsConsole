namespace CsConsole;

public interface IConsoleInput
{
    string ReadLine(CancellationToken ct);
    event EventHandler Interrupt;
}

public sealed class ConsoleInput : IConsoleInput, IDisposable
{
    public ConsoleInput() => Console.CancelKeyPress += OnCancel;
    void OnCancel(object? sender, ConsoleCancelEventArgs e)
    {
        e.Cancel = true;
        Interrupt?.Invoke(sender, e);
    }
    public string ReadLine(CancellationToken ct) => Console.ReadLine() ?? "";
    public event EventHandler? Interrupt;
    public void Dispose() => Console.CancelKeyPress -= OnCancel;
}