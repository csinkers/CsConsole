namespace CsConsole;

public delegate Task CommandMethod<in T>(ArgumentSource args, IConsoleOutput o, T state, CancellationToken ct);