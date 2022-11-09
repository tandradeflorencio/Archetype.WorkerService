using WorkerService.Archetype.Services.Interfaces;

namespace WorkerService.Archetype.Services
{
    public class CustomService : ICustomService
    {
        private readonly Serilog.ILogger _logger;

        private const string LogPrefix = $"{ConstantsUtil.LogPrefix}{nameof(CustomService)} - ";

        public CustomService(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> DoSomethingAsync()
        {
            _logger.Information($"{LogPrefix} ({nameof(DoSomethingAsync)}) Starting something.");

            await Task.Delay(2000);

            _logger.Information($"{LogPrefix} ({nameof(DoSomethingAsync)}) Something finished.");

            return true;
        }
    }
}