using ArzuhalCI.Domain.Customers;
using ArzuhalCI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ArzuhalCI.Infrastructure.Repositories;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Customer?> GetByIdentityAsync(string identityId, CancellationToken cancellationToken)
    {
        return await _context.Customers.FirstOrDefaultAsync(x => x.IdentityId == identityId, cancellationToken);
    }


    public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(Email email)
    {
        return !await _context.Customers.AnyAsync(c => c.Email == email);
    }

    public void Insert(Customer customer)
    {
        _context.Customers.Add(customer);
    }
}