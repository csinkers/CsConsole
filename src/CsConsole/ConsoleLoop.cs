using System.Text;

namespace CsConsole;

public class ConsoleLoop<TState>(CommandParser<TState> parser, TState state) where TState : ICommandState
{
    public async Task RunMain(IConsoleInput i, IConsoleOutput o)
    {
        var cts = new CancellationTokenSource();
        i.Interrupt += OnInterrupt;

        while (!state.Done)
        {
            var line = i.ReadLine(cts.Token);
            var parts = SplitLine(line);
            try
            {
                await parser.Handle(parts, o, state, cts.Token);
            }
            catch (ConsoleCommandException cce)
            {
                o.WithForeground(ConsoleColor.Red, cce.Message, static (o2, msg) => o2.WriteLine(msg));
            }
        }

        i.Interrupt -= OnInterrupt;
        return;

        void OnInterrupt(object? sender, EventArgs args)
        {
            cts.Cancel();
            cts = new CancellationTokenSource();
        }
    }

    static List<string> SplitLine(string? line)
    {
        if (string.IsNullOrEmpty(line))
            return [];

        var sb = new StringBuilder();
        var results = new List<string>();
        bool quoted = false;
        bool escaped = false;
        for (int i = 0; i < line.Length; i++)
        {
            var c = line[i];
            switch (c)
            {
                case '\\':
                    if (escaped)
                        sb.Append('\\');
                    else
                        escaped = true;
                    break;

                case '"':
                    if (escaped)
                    {
                        escaped = false;
                        sb.Append('"');
                    }
                    else if (quoted)
                        quoted = false;
                    else
                        quoted = true;

                    break;

                case ' ':
                    if (!quoted)
                    {
                        if (sb.Length > 0)
                            results.Add(sb.ToString());

                        sb.Clear();
                    }
                    else sb.Append(c);
                    break;

                case 'n': sb.Append(escaped ? '\n' : c); break;
                case 'r': sb.Append(escaped ? '\r' : c); break;
                case 't': sb.Append(escaped ? '\t' : c); break;
                default: sb.Append(c); break;
            }
        }

        if (sb.Length > 0)
            results.Add(sb.ToString());

        return results;
    }
}