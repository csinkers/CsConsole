namespace CsConsole;

/// <summary>
/// The base interface for console input sources
/// </summary>
public interface IConsoleInput
{
    /// <summary>
    /// Retrieves a line of input, blocking until one is available or the cancellation token is triggered.
    /// </summary>
    string ReadLine(CancellationToken ct);

    /// <summary>
    /// Event triggered when an interrupt signal is received (e.g. Ctrl+C)
    /// </summary>
    event EventHandler Interrupt;
}
