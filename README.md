# CsConsole
CsConsole is a simple C# console application utility library that simplifies creating interactive console applications.

Example usage:
```csharp
using CsConsole;

namespace CsConsole.Example;

public class SomeState : ICommandState
{
    public int Value { get; set; }
    public bool Done { get; set; }
}

internal class Program
{
    public static async Task Main()
    {
        var parser = new CommandParser<SomeState>();

        parser.Add(new ClearCommand());
        parser.Add(new HelpCommand(parser));
        parser.Add(
            new SyncCommand<SomeState>(
                "set",
                (args, _, state) =>
                {
                    int v = args.Int("value");
                    state.Value = v;
                }
            )
            {
                Description = "Sets the state value to the given integer",
                Usage = "<value>: The integer value to set",
            }
        );

        parser.Add(
            new SyncCommand<SomeState>(
                "get",
                (_, output, state) => output.WriteLine(state.Value.ToString())
            )
        );

        parser.Add(
            new SyncCommand<SomeState>(["quit", "q", "exit"], (_, _, state) => state.Done = true)
            {
                Description = "Exits the program",
            }
        );

        var loop = new ConsoleLoop<SomeState>(parser, new SomeState());
        var cin = new ConsoleInput();
        var cout = new ConsoleOutput();
        await loop.RunMain(cin, cout);
    }
}
```
