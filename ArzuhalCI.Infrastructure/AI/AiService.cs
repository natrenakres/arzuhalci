using ArzuhalCI.Application.Abstractions.Ai;
using Microsoft.Extensions.AI;

namespace ArzuhalCI.Infrastructure.AI;

public class AiService : IAiService
{
    private readonly IChatClient _chatClient;

    public AiService(IChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task<string?> Chat(string? prompt)
    {
        if (prompt is null)
        {
            throw new ArgumentNullException(nameof(prompt));
        }

        var response = await _chatClient.CompleteAsync(prompt);

        return response.Message.Text;
    }

}