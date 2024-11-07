using ArzuhalCI.Application.Abstractions.Messaging;

namespace ArzuhalCI.Application.Customers.Get;

public record GetCustomers() : IQuery<List<CustomerResponse>>;