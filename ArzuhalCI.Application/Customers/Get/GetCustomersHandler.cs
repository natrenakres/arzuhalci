using System.Data;
using ArzuhalCI.Application.Abstractions.Data;
using ArzuhalCI.Application.Abstractions.Messaging;
using ArzuhalCI.Domain.Customers;
using ArzuhalCI.SharedKernel;
using Dapper;

namespace ArzuhalCI.Application.Customers.Get;

public class GetCustomersHandler : IQueryHandler<GetCustomers, List<CustomerResponse>>
{
    private readonly IDbConnectionFactory _factory;

    public GetCustomersHandler(IDbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<Result<List<CustomerResponse>>> Handle(GetCustomers request, CancellationToken cancellationToken)
    {
        const string sql =
            """
                SELECT
                    c.id as Id,
                    c.email as Email,
                    c.name as Name,
                    c.identity_id as IdentityId
                FROM customers c
            """;

        using var connection = _factory.GetOpenConnection();
        var results = await connection.QueryAsync<CustomerResponse>(sql);

        var customers = results.ToList();
        return !customers.Any() ? 
            Result.Failure<List<CustomerResponse>>(CustomerErrors.NotFoundByAll) : 
            customers;
    }
}