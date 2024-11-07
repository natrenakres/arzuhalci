using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Domain.Customers;

public sealed record CustomerAddedDomainEvent(Guid CustomerId) : IDomainEvent;