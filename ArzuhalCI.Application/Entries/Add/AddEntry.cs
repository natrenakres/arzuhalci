using ArzuhalCI.Application.Abstractions.Messaging;
using ArzuhalCI.Application.Entries.Get;

namespace ArzuhalCI.Application.Entries.Add;

public record AddEntry(string Prompt) : ICommand<EntryResponse>;