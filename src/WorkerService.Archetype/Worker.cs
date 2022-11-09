using System.Diagnostics;
using WorkerService.Archetype.Services.Interfaces;

namespace WorkerService.Archetype
{
    public class Worker : BackgroundService
    {
        private readonly Serilog.ILogger _logger;

        private readonly ICustomService _customService;

        private const string LogPrefix = $"{ConstantsUtil.LogPrefix}{nameof(Worker)} - ";

        public Worker(Serilog.ILogger logger, ICustomService customService)
        {
            _logger = logger;
            _customService = customService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var stopWatch = new Stopwatch();

            while (!stoppingToken.IsCancellationRequested)
            {
                stopWatch.Restart();

                _logger.Information($"{LogPrefix} ({nameof(ExecuteAsync)}) Worker running.");

                await _customService.DoSomethingAsync();

                stopWatch.Stop();

                _logger.Information($"{LogPrefix} ({nameof(ExecuteAsync)}) Worker finished. ({stopWatch.Elapsed:mm\\:ss})");
            }

            _logger.Information($"{LogPrefix} ({nameof(ExecuteAsync)}) Worker canceled.");
        }
    }
}