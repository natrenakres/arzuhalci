using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArzuhalCI.Web.Api.OpenApi;


public class ConfigureSwaggerGenOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "ArzuhalCI.Api",
            Version = "v1",
            Description = "API Documentation for ArzuhalCI"
        });
    }

    public void Configure(string? name, SwaggerGenOptions options)
    {
        Configure(options);
    }
}
