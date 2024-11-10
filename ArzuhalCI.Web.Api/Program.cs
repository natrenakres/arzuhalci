using ArzuhalCI.Application;
using ArzuhalCI.Infrastructure;
using ArzuhalCI.Web.Api;
using ArzuhalCI.Web.Api.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddApplication()
    .AddApi()
    .AddInfrastructure(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();
}

app.UseHttpsRedirection();

app.MapHealthChecks("health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseRequestContextLogging();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();