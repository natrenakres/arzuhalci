using ArzuhalCI.Web.Api.Infrastructure;
using ArzuhalCI.Web.Api.OpenApi;
using Asp.Versioning;

namespace ArzuhalCI.Web.Api;

public static class DependencyInjection
{

    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        services.ConfigureOptions<ConfigureSwaggerGenOptions>();

        return services;

    }
    
}