using ArzuhalCI.Application.Abstractions.Messaging;

namespace ArzuhalCI.Application.Entries.Add;

public record AddEntry(string Prompt) : ICommand<Guid>;