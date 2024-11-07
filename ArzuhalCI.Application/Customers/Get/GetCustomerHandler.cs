using ArzuhalCI.Application.Abstractions.Data;
using ArzuhalCI.Application.Abstractions.Messaging;
using ArzuhalCI.Domain.Customers;
using ArzuhalCI.SharedKernel;
using Dapper;

namespace ArzuhalCI.Application.Customers.Get;


public class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerResponse>
{
    private readonly IDbConnectionFactory _factory;

    public GetCustomerHandler(IDbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<Result<CustomerResponse>> Handle(GetCustomer request, CancellationToken cancellationToken)
    {
        const string sql =
            """
                SELECT
                    c.id as Id,
                    c.email as Email,
                    c.name as Name,
                    c.identity_id as IdentityId
                FROM customers c
                WHERE c.id = @CustomerId
            """;

        using var connection = _factory.GetOpenConnection();
        var result = await connection.QueryFirstOrDefaultAsync<CustomerResponse>(
            sql,
            request);

        if (result is null)
        {
            return Result.Failure<CustomerResponse>(CustomerErrors.NotFound(request.CustomerId));
        }
        
        return result;


    }
}