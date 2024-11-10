using ArzuhalCI.Domain.Entries;
using ArzuhalCI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ArzuhalCI.Infrastructure.Repositories;

public class EntryRepository : IEntryRepository
{
    private readonly ApplicationDbContext _context;

    public EntryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Insert(Entry entry)
    {
        _context.Entries.Add(entry);
    }

    public async Task<Entry?> GetCustomerEntry(Guid entryId, string identityId, CancellationToken cancellationToken)
    {
        var entry = await _context.Entries
            .Include(c => c.Customer)
            .Include(c => c.Analyse)
            .FirstOrDefaultAsync(e =>
                e.Id == entryId &&
                e.Customer.IdentityId == identityId,
                cancellationToken
            );

        return entry;
    }

    public async Task<Entry?> GetAsync(Guid entryId, CancellationToken cancellationToken)
    {
        return await _context.Entries
            .Include(x => x.Analyse)
            .FirstOrDefaultAsync(e => e.Id == entryId,
                cancellationToken);
    }
    
    public async Task<Entry?> GetAsync(Guid entryId, string identityId, CancellationToken cancellationToken)
    {
        return await _context.Entries
            .Include(x => x.Analyse)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(
                e => e.Id == entryId && e.Customer.IdentityId == identityId,
                cancellationToken);
    }
}