using ArzuhalCI.Application.Abstractions.Messaging;
using MediatR;

namespace ArzuhalCI.Application.Entries.AddAnalyse;

public record AddAnalyse(Guid EntryId,
    string Mood, string Subject, 
    bool Negative, string Summary, int SentimentScore, string Petition) : ICommand;