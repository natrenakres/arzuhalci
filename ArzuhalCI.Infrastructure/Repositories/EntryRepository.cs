using ArzuhalCI.Domain.Entries;
using ArzuhalCI.Infrastructure.Database;

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
}