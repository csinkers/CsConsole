using System.Net;

namespace CsConsole;

public interface IConsoleOutput
{
    void Clear();
    void Write(string message);
    void WriteLine();
    void WriteLine(string message);
    ConsoleColor Foreground {get; set; }
    ConsoleColor Background {get; set; }

    void WithForeground<TContext>(ConsoleColor color, TContext context, Action<IConsoleOutput, TContext> action)
    {
        var old = Foreground;
        Foreground = color;
        action(this, context);
        Foreground = old;
    }
}