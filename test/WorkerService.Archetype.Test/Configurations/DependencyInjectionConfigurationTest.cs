using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using WorkerService.Archetype.Configurations;

namespace WorkerService.Archetype.Test.Configurations
{
    [ExcludeFromCodeCoverage]
    public class DependencyInjectionConfigurationTest : BaseTest
    {
        [Fact]
        public void ConfigureDependencies_WhenRun_ShouldFinishWithoutErrors()
        {
            //Arrange
            var service = new ServiceCollection();

            //Act
            DependencyInjectionConfiguration.ConfigureDependencies(service, _configuration);

            //Assert
            Assert.True(true);
        }
    }
}