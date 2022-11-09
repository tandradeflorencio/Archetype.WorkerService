using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NSubstitute;
using System.Diagnostics.CodeAnalysis;
using WorkerService.Archetype.Configurations;

namespace WorkerService.Archetype.Test.Configurations
{
    [ExcludeFromCodeCoverage]
    public class HealthCheckConfigurationTest : BaseTest
    {
        [Fact]
        public void ConfigureHealthChecks_WhenRun_ShouldFinishWithoutErrors()
        {
            //Arrange
            var service = Substitute.For<IServiceCollection>();

            //Act
            HealthCheckConfiguration.ConfigureHealthChecks(service);

            //Assert
            Assert.True(true);
        }

        [Fact]
        public void MakeResponse_WhenRun_ShouldFinishWithoutErrors()
        {
            //Arrange
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            var entries = new Dictionary<string, HealthReportEntry> { { "Entry", new HealthReportEntry(HealthStatus.Degraded, "Entry", TimeSpan.MaxValue, null, null) } };
            var report = new HealthReport(entries, TimeSpan.FromMinutes(1));

            //Act
            HealthCheckConfiguration.MakeResponse(context, report);

            //Assert
            Assert.True(true);
        }
    }
}