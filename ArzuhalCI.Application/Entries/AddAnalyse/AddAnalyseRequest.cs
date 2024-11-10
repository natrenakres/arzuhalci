namespace ArzuhalCI.Application.Entries.AddAnalyse;

public class AddAnalyseRequest
{
    public Guid EntryId { get; set; }
    public string Mood { get; set; }
    public string Subject { get; set; }
    public bool Negative { get; set; }
    public string Summary { get; set; }
    public int SentimentScore { get; set; }
    public string Petition { get; set; }
}