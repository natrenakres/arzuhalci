using ArzuhalCI.Web.Api.Infrastructure;
using ArzuhalCI.Web.Api.OpenApi;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://dev-0005ifbbc2xshhn7.us.auth0.com/";
                options.Audience = "http://localhost:3001";
                options.RequireHttpsMetadata = false;
            });

        return services;

    }
    
}