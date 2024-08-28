namespace CsConsole;

public class CommandWrapper<TState> : ICommand<TState> where TState : ICommandState
{
    readonly Func<ArgumentSource, IConsoleOutput, TState, CancellationToken, Task> _invoke;
    readonly ICommand _command;

    public static ICommand<TState> Wrap(ICommand command) =>
        command switch
        {
            ICommand<TState> stateful => stateful,
            ISyncCommand<TState> sync => new CommandWrapper<TState>(sync),
            IStatelessSyncCommand statelessSync => new CommandWrapper<TState>(statelessSync),
            IStatelessCommand stateless => new CommandWrapper<TState>(stateless),
            _ => throw new ArgumentOutOfRangeException($"Unexpected command type \"{command.GetType().Name}\"")
        };

    public CommandWrapper(ISyncCommand<TState> command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
        _invoke = (args, o, state, _) =>
        {
            command.Invoke(args, o, state);
            return Task.CompletedTask;
        };
    }

    public CommandWrapper(IStatelessSyncCommand command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
        _invoke = (args, o, _, _) =>
        {
            command.Invoke(args, o);
            return Task.CompletedTask;
        };
    }

    public CommandWrapper(IStatelessCommand command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
        _invoke = (args, o, _, ct) => command.InvokeAsync(args, o, ct);
    }

    public Task InvokeAsync(ArgumentSource args, IConsoleOutput o, TState state, CancellationToken ct) => _invoke(args, o, state, ct);

    public string[] Names => _command.Names;
    public string? Description => _command.Description;
    public string? ShortDescription => _command.ShortDescription;
    public string? Usage => _command.Usage;
}