using ArzuhalCI.Domain.Entries;
using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Domain.Petitions;

public class Petition : Entity
{
    public Guid EntryId { get; private set; }
    public Entry Entry { get; private set; }

    public Content Content { get; private set; }
}