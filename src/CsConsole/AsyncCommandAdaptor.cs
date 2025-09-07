namespace CsConsole;

/// <summary>
/// An adaptor that wraps a synchronous or asynchronous command and exposes it as an asynchronous command with state.
/// </summary>
public class AsyncCommandAdaptor<TState> : IAsyncCommand<TState>
    where TState : ICommandState
{
    readonly Func<ArgumentSource, IConsoleOutput, TState, CancellationToken, Task> _invoke;
    readonly ICommand _command;

    /// <summary>
    /// Wraps the given command in an async command adaptor (if required).
    /// </summary>
    public static IAsyncCommand<TState> Wrap(ICommand command) =>
        command switch
        {
            IAsyncCommand<TState> stateful => stateful,
            ISyncCommand<TState> sync => new AsyncCommandAdaptor<TState>(sync),
            ISyncCommand statelessSync => new AsyncCommandAdaptor<TState>(statelessSync),
            IAsyncCommand stateless => new AsyncCommandAdaptor<TState>(stateless),
            _ => throw new ArgumentOutOfRangeException(
                $"Unexpected command type \"{command.GetType().Name}\""
            ),
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

    /// <inheritdoc />
    public Task InvokeAsync(
        ArgumentSource args,
        IConsoleOutput o,
        TState state,
        CancellationToken ct
    ) => _invoke(args, o, state, ct);

    /// <inheritdoc />
    public string[] Names => _command.Names;

    /// <inheritdoc />
    public string? Description => _command.Description;

    /// <inheritdoc />
    public string? ShortDescription => _command.ShortDescription;

    /// <inheritdoc />
    public string? Usage => _command.Usage;
}
