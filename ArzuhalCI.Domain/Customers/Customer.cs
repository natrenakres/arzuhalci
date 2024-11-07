using ArzuhalCI.Domain.Entries;
using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Domain.Customers;

public sealed class Customer : Entity
{
    public Customer()
    {
        
    }

    private Customer(Guid id, Email email, Name name, string identityId)
    : base(id)
    {
        Email = email;
        Name = name;
        IdentityId = identityId;
    }

    public Email Email { get; private set; }

    public Name Name { get; private set; }

    public string IdentityId { get; private set; }

    public List<Entry> Entries { get; private set; }

    public static Customer Create(Email email, Name name, string identityId)
    {
        var customer = new Customer(Guid.NewGuid(), email, name, identityId);
        
        customer.Raise(new CustomerAddedDomainEvent(customer.Id));

        return customer;
    }
}