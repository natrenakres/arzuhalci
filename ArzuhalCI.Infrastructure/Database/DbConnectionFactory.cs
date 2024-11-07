using System.Data;
using ArzuhalCI.Application.Abstractions.Data;
using Npgsql;

namespace ArzuhalCI.Infrastructure.Database;

internal sealed class DbConnectionFactory : IDbConnectionFactory
{
    private readonly NpgsqlDataSource _dataSource;

    public DbConnectionFactory(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IDbConnection GetOpenConnection()
    {
        NpgsqlConnection connection = _dataSource.OpenConnection();

        return connection;
    }
}