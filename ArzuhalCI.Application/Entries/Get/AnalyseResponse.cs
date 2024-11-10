namespace ArzuhalCI.Application.Entries.Get;

public class AnalyseResponse
{
    public string? Mood { get; set; }
    public string? Subject { get; set; }
    public bool Negative { get; set; }
    public string? Summary { get; set; }
    public int? SentimentScore { get; set; }
}