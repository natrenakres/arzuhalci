using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Domain.Entries;

public record EntryAddedDomainEvent(Guid EntryId) : IDomainEvent;