namespace CsConsole;

/// <summary>
/// A console input source that reads from the standard console input.
/// </summary>
public sealed class ConsoleInput : IConsoleInput, IDisposable
{
    /// <summary>
    /// Creates a new instance of the console input source.
    /// </summary>
    public ConsoleInput() => Console.CancelKeyPress += OnCancel;

    void OnCancel(object? sender, ConsoleCancelEventArgs e)
    {
        e.Cancel = true;
        Interrupt?.Invoke(sender, e);
    }

    /// <inheritdoc />
    public string ReadLine(CancellationToken ct) => Console.ReadLine() ?? "";

    /// <inheritdoc />
    public event EventHandler? Interrupt;

    /// <inheritdoc />
    public void Dispose() => Console.CancelKeyPress -= OnCancel;
}
