namespace CsConsole;

public class AsyncCommandAdaptor<TState> : IAsyncCommand<TState> where TState : ICommandState
{
    readonly Func<ArgumentSource, IConsoleOutput, TState, CancellationToken, Task> _invoke;
    readonly ICommand _command;

    public static IAsyncCommand<TState> Wrap(ICommand command) =>
        command switch
        {
            IAsyncCommand<TState> stateful => stateful,
            ISyncCommand<TState> sync => new AsyncCommandAdaptor<TState>(sync),
            ISyncCommand statelessSync => new AsyncCommandAdaptor<TState>(statelessSync),
            IAsyncCommand stateless => new AsyncCommandAdaptor<TState>(stateless),
            _ => throw new ArgumentOutOfRangeException($"Unexpected command type \"{command.GetType().Name}\"")
        };

    AsyncCommandAdaptor(ISyncCommand<TState> command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
        _invoke = (args, o, state, _) =>
        {
            command.Invoke(args, o, state);
            return Task.CompletedTask;
        };
    }

    AsyncCommandAdaptor(ISyncCommand command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
        _invoke = (args, o, _, _) =>
        {
            command.Invoke(args, o);
            return Task.CompletedTask;
        };
    }

    AsyncCommandAdaptor(IAsyncCommand command)
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