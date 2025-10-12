namespace CsConsole;

/// <summary>
/// Custom exception type for console command errors
/// </summary>
public class ConsoleCommandException : Exception
{
    /// <summary>
    /// Creates a new instance of the exception with no message.
    /// </summary>
    public ConsoleCommandException() { }

    /// <summary>
    /// Creates a new instance of the exception with the given message.
    /// </summary>
    public ConsoleCommandException(string message)
        : base(message) { }

    /// <summary>
    /// Creates a new instance of the exception with the given message and inner exception.
    /// </summary>
    public ConsoleCommandException(string message, Exception innerException)
        : base(message, innerException) { }
}
