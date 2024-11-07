using ArzuhalCI.Application.Abstractions.Messaging;

namespace ArzuhalCI.Application.Customers.Add;

public record AddCustomer(string Email, string Name, string IdentityId) : ICommand<Guid>;
    
