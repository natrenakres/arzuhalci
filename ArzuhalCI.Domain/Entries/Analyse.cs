using ArzuhalCI.Domain.Customers;
using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Domain.Entries;

public class Analyse : Entity
{
    public Guid EntryId { get; private set; }
    public Entry Entry { get; private set; }
    
    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public AnalyseProps AnalyseProps { get; private set; }
}