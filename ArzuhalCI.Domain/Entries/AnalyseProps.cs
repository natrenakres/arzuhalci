namespace ArzuhalCI.Domain.Entries;

public record AnalyseProps(string Mood, string Subject, bool Negative, string Summary, int SentimentScore);