using ArzuhalCI.Application.Abstractions.Messaging;

namespace ArzuhalCI.Application.Customers.Get;

public record GetCustomer(Guid CustomerId) : IQuery<CustomerResponse>;
