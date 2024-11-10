using ArzuhalCI.Application.Abstractions.Data;
using ArzuhalCI.Application.Abstractions.Messaging;
using ArzuhalCI.Domain.Customers;
using Dapper;

namespace ArzuhalCI.Application.Entries.Get;

public record GetEntry(Guid EntryId) : IQuery<EntryResponse>;