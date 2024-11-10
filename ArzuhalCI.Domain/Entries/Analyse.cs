using ArzuhalCI.Domain.Customers;
using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Domain.Entries;

public class Analyse : Entity
{
    public Analyse() { }
    private Analyse(Guid id, string mood, bool negative, int sentimentScore, string subject, string petition, string summary)
    : base(id)
    {
        AnalyseProps = new AnalyseProps(mood, subject, negative, summary, sentimentScore);
    }

    public Guid EntryId { get; private set; }
    public Entry Entry { get; private set; } = null!;
    public AnalyseProps AnalyseProps { get; private set; }
    public Petition Petition { get; private set; } = null!;

    public static Analyse Create(string mood, bool negative, int sentimentScore, string subject, string petition, string summary)
    {
        var analyse = new Analyse(Guid.NewGuid(),
            mood, negative, sentimentScore, subject, petition, summary);

        analyse.Raise(new AnalyseAddedDomainEvent(analyse.Id));
        
        return analyse;
    }
}