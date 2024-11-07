using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Infrastructure.Time;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}