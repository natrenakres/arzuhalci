using ArzuhalCI.Domain.Customers;
using ArzuhalCI.Domain.PromptEntries;
using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Domain.Entries;

public class Entry : Entity
{
    public Entry() { }
    private Entry(Guid id, string prompt, Guid customerId)
    : base(id)
    {
        Prompt = new Prompt(prompt);
        CustomerId = customerId;
        Status = EntryStatus.Draft;
    }

    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public Prompt Prompt { get; private set; }
    public Output Output { get; private set; }
    public EntryStatus Status { get; private set; }
    
    public Guid? AnalyseId { get; private set; }
    public Analyse? Analyse { get; private set; }


    public static Entry Create(string prompt, Guid customerId)
    {
        var entry = new Entry(Guid.NewGuid(), prompt, customerId);

        entry.Raise(new EntryAddedDomainEvent(entry.Id));
        
        return entry;
    }

    public void AddOutput(string output)
    {
        Output = new Output(output);
    }

    public Entry AddAnalyse(string mood, bool negative, int sentimentScore, string subject, string petition, string summary)
    {
        var analyse = Analyse.Create(mood, negative, sentimentScore, subject, petition, summary);
        AnalyseId = analyse.Id;

        return this;
    }

    public void SetAnalysed()
    {
        Status = EntryStatus.Analysed;
    }
}