namespace CsConsole;

/// <summary>
/// Delegate type for synchronous command methods
/// </summary>
public delegate void SyncCommandMethod(ArgumentSource args, IConsoleOutput o);

/// <summary>
/// Delegate type for synchronous command methods that use a state object
/// </summary>
public delegate void SyncCommandMethod<in T>(ArgumentSource args, IConsoleOutput o, T state);
