using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System.Diagnostics.CodeAnalysis;
using WorkerService.Archetype.Configurations;

namespace WorkerService.Archetype.Test.Configurations
{
    [ExcludeFromCodeCoverage]
    public class LogConfigurationTest : BaseTest
    {
        [Fact]
        public void ConfigureLogs_WhenRun_ShouldFinishWithoutErrors()
        {
            //Arrange
            var service = Substitute.For<IServiceCollection>();

            //Act
            LogConfiguration.ConfigureLogs(service);

            //Assert
            Assert.True(true);
        }
    }
}