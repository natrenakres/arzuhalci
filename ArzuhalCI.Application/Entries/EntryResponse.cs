using ArzuhalCI.Application.Entries.Get;
using ArzuhalCI.Domain.Entries;
using ArzuhalCI.Domain.PromptEntries;

namespace ArzuhalCI.Application.Entries;

public class EntryResponse
{
    public Guid Id { get; set; }
    public string? Prompt { get; set; }

    public string? Output { get; set; }
    public AnalyseResponse AnalyseResponse { get; set; } = new();


    public static EntryResponse Map(Entry entry)
    {
        return new EntryResponse
        {
            Id = entry.Id,
            Status = entry.Status,
            Prompt = entry.Prompt.Content,
            Output = entry.Output?.Text,
            AnalyseResponse =
            {
                Mood = entry.Analyse?.AnalyseProps.Mood,
                SentimentScore = entry.Analyse?.AnalyseProps.SentimentScore,
                Negative = entry.Analyse?.AnalyseProps.Negative ?? false,
                Summary = entry.Analyse?.AnalyseProps.Summary,
                Subject = entry.Analyse?.AnalyseProps.Subject
            }
        };
    }

    public EntryStatus Status { get; set; }
}