namespace ArzuhalCI.Domain.Entries;

public interface IEntryRepository
{
    void Insert(Entry entry);
    Task<Entry?> GetCustomerEntry(Guid entryId, string identityId, CancellationToken cancellationToken);
    Task<Entry?> GetAsync(Guid entryId, CancellationToken cancellationToken);
    Task<Entry?> GetAsync(Guid entryId, string identityId, CancellationToken cancellationToken);
}