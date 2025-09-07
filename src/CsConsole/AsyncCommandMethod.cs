namespace CsConsole;

/// <summary>
/// Delegate type for asynchronous command methods
/// </summary>
public delegate Task AsyncCommandMethod(
    ArgumentSource args,
    IConsoleOutput o,
    CancellationToken ct
);

/// <summary>
/// Delegate type for asynchronous command methods that use a state object
/// </summary>
public delegate Task AsyncCommandMethod<in T>(
    ArgumentSource args,
    IConsoleOutput o,
    T state,
    CancellationToken ct
);
