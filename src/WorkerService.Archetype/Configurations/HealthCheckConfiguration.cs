using Microsoft.AspNetCore.Http;
using System.Text.Json;
using WorkerService.Archetype.Models.Responses;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WorkerService.Archetype.Configurations
{
    public static class HealthCheckConfiguration
    {
        public static IServiceCollection ConfigureHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();

            return services;
        }

        public static Task MakeResponse(HttpContext context, HealthReport healthReport)
        {
            context.Response.ContentType = "application/json";

            var resultado = new HealthCheckResponse
            {
                Status = healthReport.Status.ToString(),
                Description = "WorkerService.Archetype",
                Results = healthReport.Entries.Select(pair =>
                    new HealthCheckResponse
                    {
                        Status = pair.Value.Status.ToString(),
                        Description = pair.Key
                    }).ToList()
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(resultado));
        }
    }
}