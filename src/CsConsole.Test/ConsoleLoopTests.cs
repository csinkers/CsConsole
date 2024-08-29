namespace CsConsole.Test;

public class ConsoleLoopTests
{
    class TestState : ICommandState
    {
        public bool Done { get; set; }
    }

    [Fact]
    public async Task QuitCommand()
    {
        var quit = new SyncCommand<TestState>("quit", (_, _, state) => state.Done = true);
        var parser = new CommandParser<TestState>();
        parser.Add(quit);

        var loop = new ConsoleLoop<TestState>(parser, new TestState());
        var console = new TestConsole("quit");
        await loop.RunMain(console, console);
    }
}
