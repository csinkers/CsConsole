namespace CsConsole;

public class ConsoleCommandException : Exception
{
    public ConsoleCommandException() { }

    public ConsoleCommandException(string message)
        : base(message) { }
}
