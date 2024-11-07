namespace ArzuhalCI.Application.Customers.Get;

public sealed record CustomerResponse
{
    public Guid Id { get; init; }

    public string Email { get; init; }

    public string Name { get; init; }

    public string IdentityId { get; set; }
}