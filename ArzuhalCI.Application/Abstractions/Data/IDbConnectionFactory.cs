using System.Data;

namespace ArzuhalCI.Application.Abstractions.Data;

public interface IDbConnectionFactory
{
    IDbConnection GetOpenConnection();
}