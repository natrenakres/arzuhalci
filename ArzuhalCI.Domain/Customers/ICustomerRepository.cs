namespace ArzuhalCI.Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdentityAsync(string identityId, CancellationToken cancellationToken);
    Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsEmailUniqueAsync(Email email);

    void Insert(Customer customer);
}