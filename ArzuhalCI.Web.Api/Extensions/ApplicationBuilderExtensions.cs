using Asp.Versioning.ApiExplorer;

namespace ArzuhalCI.Web.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSwaggerWithUi(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "ArzuhalCI.Api v1");
            options.RoutePrefix = string.Empty; 
        });

        return app;
    }
}
