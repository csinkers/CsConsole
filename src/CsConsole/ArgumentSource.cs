namespace CsConsole;

/// <summary>
/// Helper type to simplify argument parsing from a string array
/// </summary>
/// <param name="args">The argument array to parse</param>
/// <param name="n">The index of the first unread argument in the array</param>
public class ArgumentSource(IList<string> args, int n = 0)
{
    readonly IList<string> _args = args ?? throw new ArgumentNullException(nameof(args));
    int _n = n;

    /// <summary>
    /// The number of remaining unread arguments
    /// </summary>
    public int Remaining => _args.Count - _n;

    /// <summary>
    /// Reads the next argument, throwing an exception if there are no more arguments
    /// </summary>
    /// <param name="name">The argument name to use in the exception message if the argument is not supplied.</param>
    /// <returns>The argument value as a string</returns>
    /// <exception cref="ConsoleCommandException">Thrown if there are no more unread arguments</exception>
    public string Arg(string name) =>
        Optional() ?? throw new ConsoleCommandException($"Expected parameter \"{name}\"");

    /// <summary>
    /// Reads the next argument, returning null if there are no more arguments
    /// </summary>
    /// <returns>The next argument, or null.</returns>
    public string? Optional() => _n >= _args.Count ? null : _args[_n++];

    /// <summary>
    /// Reads the next argument and parses it as an integer, throwing an exception if there are no more arguments or if the argument cannot be parsed as an integer.
    /// </summary>
    public int Int(string name)
    {
        var raw = Arg(name);
        if (!int.TryParse(raw, out var intValue))
            throw new ConsoleCommandException($"Could not parse \"{raw}\" as a whole number");

        return intValue;
    }
}
