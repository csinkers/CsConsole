namespace CsConsole;

public interface ICommand
{
    string[] Names { get; }
    string? Description { get; }
    string? ShortDescription { get; }
    string? Usage { get; }
}
