namespace ArzuhalCI.SharedKernel;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}