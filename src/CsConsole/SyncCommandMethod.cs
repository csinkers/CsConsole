namespace CsConsole;

public delegate void SyncCommandMethod(ArgumentSource args, IConsoleOutput o);
public delegate void SyncCommandMethod<in T>(ArgumentSource args, IConsoleOutput o, T state);
