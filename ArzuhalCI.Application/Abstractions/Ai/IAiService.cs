namespace ArzuhalCI.Application.Abstractions.Ai;

public interface IAiService
{
    Task<string?> Chat(string? prompt);
}