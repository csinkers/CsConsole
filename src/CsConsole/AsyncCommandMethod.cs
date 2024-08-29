namespace CsConsole;

public delegate Task AsyncCommandMethod(
    ArgumentSource args,
    IConsoleOutput o,
    CancellationToken ct
);
public delegate Task AsyncCommandMethod<in T>(
    ArgumentSource args,
    IConsoleOutput o,
    T state,
    CancellationToken ct
);
