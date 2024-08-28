namespace CsConsole;

public class ArgumentSource(IList<string> args, int n)
{
    readonly IList<string> _args = args ?? throw new ArgumentNullException(nameof(args));
    int _n = n;
    public int Remaining => _args.Count - _n;

    public string Arg(string name)
        => Optional() ?? throw new ConsoleCommandException($"Expected parameter \"{name}\"");
    public string? Optional() => _n >= _args.Count ? null : _args[_n++];

    public int Int(string name)
    {
        var raw = Arg(name);
        if (!int.TryParse(raw, out var intValue))
            throw new ConsoleCommandException($"Could not parse \"{raw}\" as a whole number");

        return intValue;
    }
}