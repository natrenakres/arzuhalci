using ArzuhalCI.Application.Abstractions.Ai;
using ArzuhalCI.Application.Abstractions.Authentication;
using ArzuhalCI.Application.Abstractions.Data;
using ArzuhalCI.Domain.Customers;
using ArzuhalCI.Domain.Entries;
using ArzuhalCI.Infrastructure.AI;
using ArzuhalCI.Infrastructure.Authentication;
using ArzuhalCI.Infrastructure.Database;
using ArzuhalCI.Infrastructure.Repositories;
using ArzuhalCI.Infrastructure.Time;
using ArzuhalCI.SharedKernel;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Npgsql;

namespace ArzuhalCI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddServices(configuration)
            .AddDatabase(configuration)
            .AddHealthChecks(configuration);



    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        string? connectionString = configuration.GetConnectionString("Database");
        Ensure.NotNullOrEmpty(connectionString);

        services.AddSingleton<IDbConnectionFactory>(_ =>
            new DbConnectionFactory(new NpgsqlDataSourceBuilder(connectionString).Build()));

        services.AddDbContext<ApplicationDbContext>(
            options => options
                .UseNpgsql(connectionString, npgsqlOptions =>
                    npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Default))
                .UseSnakeCaseNamingConvention());

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEntryRepository, EntryRepository>();

        return services;
    }
    
    

    private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IUserContext, UserContext>();
        services.AddTransient<IAiService, AiService>();

        services.Configure<AiSettings>(configuration.GetSection(AiSettings.SectionName));

        services.AddScoped<IChatClient>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<AiSettings>>().Value;
            return new OllamaChatClient(new Uri(options.BaseUrl), options.ModelName);
        });



        return services;
    }
    
    private static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("Database")!)
            .AddRedis(configuration.GetConnectionString("Cache")!);

        return services;
    }
    
}