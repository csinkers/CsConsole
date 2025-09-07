namespace CsConsole;

/// <summary>
/// A console output sink that writes to the standard console output.
/// </summary>
public sealed class ConsoleOutput : IConsoleOutput
{
    /// <inheritdoc />
    public ConsoleColor Foreground { get; set; } = ConsoleColor.White;

    /// <inheritdoc />
    public ConsoleColor Background { get; set; } = ConsoleColor.Black;

    /// <inheritdoc />
    public void Clear() => Console.Clear();

    /// <inheritdoc />
    public void Write(string message) => Console.Write(message);

    /// <inheritdoc />
    public void WriteLine() => Console.WriteLine();

    /// <inheritdoc />
    public void WriteLine(string message) => Console.WriteLine(message);

    /// <inheritdoc />
    public void WithForeground<TContext>(
        ConsoleColor color,
        TContext message,
        Action<IConsoleOutput, TContext> action
    )
    {
        var originalForeground = Foreground;
        Foreground = color;
        action(this, message);
        Foreground = originalForeground;
    }
}
