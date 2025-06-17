namespace CsConsole;

public sealed class ConsoleOutput : IConsoleOutput
{
    public ConsoleColor Foreground { get; set; } = ConsoleColor.White;
    public ConsoleColor Background { get; set; } = ConsoleColor.Black;

    public void Clear() => Console.Clear();

    public void Write(string message) => Console.Write(message);

    public void WriteLine() => Console.WriteLine();

    public void WriteLine(string message) => Console.WriteLine(message);

    public void WithForeground(
        ConsoleColor color,
        string message,
        Action<IConsoleOutput, string> action
    )
    {
        var originalForeground = Foreground;
        Foreground = color;
        action(this, message);
        Foreground = originalForeground;
    }
}
