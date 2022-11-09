using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using WorkerService.Archetype.Services;

namespace WorkerService.Archetype.Test.Services
{
    [ExcludeFromCodeCoverage]
    public class CustomServiceTest : BaseTest
    {
        [Fact]
        public async Task DoSomethingAsync_WhenToDoSomething_ShouldReturnTrue()
        {
            //Arrange
            //Act
            var result = await new CustomService(_logger).DoSomethingAsync();

            //Assert
            result.Should().BeTrue();
        }
    }
}