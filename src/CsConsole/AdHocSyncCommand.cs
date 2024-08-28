﻿namespace CsConsole;

public class AdHocSyncCommand<T>(string name, SyncCommandMethod<T> func)
    : ISyncCommand<T>
    where T : ICommandState
{
    public void Invoke(ArgumentSource args, IConsoleOutput o, T state) => func(args, o, state);
    public string[] Names { get; } = [name];
    public string? Description { get; init; }
    public string? ShortDescription { get; init; }
    public string? Usage { get; init; }
}