namespace ArzuhalCI.Infrastructure.AI;

public class AiSettings
{
    public static string SectionName = nameof(AiSettings);
    
    public string BaseUrl { get; set; }
    public string ModelName { get; set; }
    
}