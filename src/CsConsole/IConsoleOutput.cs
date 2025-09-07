namespace CsConsole;

/// <summary>
/// The base interface for console output sinks
/// </summary>
public interface IConsoleOutput
{
    /// <summary>
    /// Clears the console output
    /// </summary>
    void Clear();

    /// <summary>
    /// Writes a message to the console output
    /// </summary>
    void Write(string message);

    /// <summary>
    /// Writes a new line to the console output
    /// </summary>
    void WriteLine();

    /// <summary>
    /// Writes a message followed by a new line to the console output
    /// </summary>
    /// <param name="message"></param>
    void WriteLine(string message);

    /// <summary>
    /// Gets or sets the foreground color for subsequent output
    /// </summary>
    ConsoleColor Foreground { get; set; }

    /// <summary>
    /// Gets or sets the background color for subsequent output
    /// </summary>
    ConsoleColor Background { get; set; }

    /// <summary>
    /// Temporarily sets the foreground color while executing the provided action, then restores the original color.
    /// </summary>
    void WithForeground<TContext>(
        ConsoleColor color,
        TContext context,
        Action<IConsoleOutput, TContext> action
    )
    {
        var old = Foreground;
        Foreground = color;
        action(this, context);
        Foreground = old;
    }
}
