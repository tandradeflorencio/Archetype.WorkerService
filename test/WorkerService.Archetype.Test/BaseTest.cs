using AutoFixture;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using System.Diagnostics.CodeAnalysis;
using WorkerService.Archetype.Services;
using WorkerService.Archetype.Services.Interfaces;

namespace WorkerService.Archetype.Test
{
    [ExcludeFromCodeCoverage]
    public class BaseTest
    {
        protected readonly Fixture _fixture;

        protected readonly Serilog.ILogger _logger;

        protected readonly IConfiguration _configuration;

        protected readonly ICustomService _customService;

        public BaseTest()
        {
            _fixture = new Fixture();
            _logger = Substitute.For<Serilog.ILogger>();
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables().Build();
            _customService = Substitute.For<ICustomService>();
        }
    }
}