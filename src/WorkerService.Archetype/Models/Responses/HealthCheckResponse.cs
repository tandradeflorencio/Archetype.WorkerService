using System.Diagnostics.CodeAnalysis;

namespace WorkerService.Archetype.Models.Responses
{
    [ExcludeFromCodeCoverage]
    public class HealthCheckResponse
    {
        public string Status { get; set; }

        public string Description { get; set; }

        public object Data { get; set; }

        public IList<HealthCheckResponse> Results { get; set; }
    }
}