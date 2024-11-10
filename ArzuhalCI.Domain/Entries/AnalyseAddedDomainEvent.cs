using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Domain.Entries;

public record AnalyseAddedDomainEvent(Guid AnalyseId) : IDomainEvent;