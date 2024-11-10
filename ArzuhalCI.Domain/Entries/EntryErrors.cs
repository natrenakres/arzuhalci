using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Domain.Entries;

public static class EntryErrors
{
    public static Error NotFound() => Error.NotFound(
        "Entries.NotFound",
        $"The entry was not found");
}