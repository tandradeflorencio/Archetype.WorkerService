using Serilog;

namespace WorkerService.Archetype.Configurations
{
    public static class LogConfiguration
    {
        public static void ConfigureLogs(this IServiceCollection services)
        {
            services.AddSingleton(Log.Logger);
        }
    }
}