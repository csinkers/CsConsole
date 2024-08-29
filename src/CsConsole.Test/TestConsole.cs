using System.Text;

namespace CsConsole.Test;

public class TestConsole(params string[] input) : IConsoleInput, IConsoleOutput
{
    int _inputIndex;

    public StringBuilder Output { get; } = new();
    public event EventHandler? Interrupt;
    public ConsoleColor Foreground { get; set; } = ConsoleColor.White;
    public ConsoleColor Background { get; set; } = ConsoleColor.Black;

    public string ReadLine(CancellationToken ct) =>
        _inputIndex >= input.Length
            ? throw new InvalidOperationException("Exhausted all console input")
            : input[_inputIndex++];

    public void Clear() => Output.Clear();

    public void Write(string message) => Output.Append(message);

    public void WriteLine() => WriteLine("");

    public void WriteLine(string message) => Write(message + Environment.NewLine);
}
