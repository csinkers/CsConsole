namespace CsConsole;

/// <summary>
/// The command parser is responsible for parsing command line input and invoking the appropriate command.
/// </summary>
/// <typeparam name="TState"></typeparam>
public class CommandParser<TState> : ICommandParser
    where TState : ICommandState
{
    readonly object _syncRoot = new();
    readonly Dictionary<string, IAsyncCommand<TState>> _commands =
        new(StringComparer.InvariantCultureIgnoreCase);

    /// <inheritdoc />
    public IEnumerable<ICommand> Commands
    {
        get
        {
            lock (_syncRoot)
                return _commands.Values.Distinct();
        }
    }

    /// <inheritdoc />
    public bool TryGetCommand(string name, out ICommand? command)
    {
        lock (_syncRoot)
        {
            var returnVal = _commands.TryGetValue(name, out var typedCommand);
            command = typedCommand;
            return returnVal;
        }
    }

    /// <summary>
    /// Registers a command with the parser.
    /// </summary>
    public void Add(ICommand command)
    {
        var typedCommand = AsyncCommandAdaptor<TState>.Wrap(command);
        lock (_syncRoot)
        {
            foreach (var alias in typedCommand.Names)
            {
                if (_commands.TryGetValue(alias, out var existing))
                {
                    throw new ConsoleCommandException(
                        $"Could not register alias \"{alias}\" for command {typedCommand} as it is already registered by command {existing}"
                    );
                }
            }

            foreach (var alias in typedCommand.Names)
                _commands[alias] = typedCommand;
        }
    }

    /// <summary>
    /// Parses the given arguments and invokes the appropriate command.
    /// </summary>
    public async Task Handle(
        IList<string> args,
        IConsoleOutput o,
        TState state,
        CancellationToken ct
    )
    {
        IAsyncCommand<TState>? command;
        lock (_syncRoot)
            if (!_commands.TryGetValue(args[0], out command))
                throw new ConsoleCommandException($"Unknown command \"{args[0]}\"");

        var getter = new ArgumentSource(args, 1);
        await command.InvokeAsync(getter, o, state, ct);
    }
}
