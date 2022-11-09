using WorkerService.Archetype.Services;
using WorkerService.Archetype.Services.Interfaces;

namespace WorkerService.Archetype.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuracao)
        {
            services.AddSingleton<ICustomService, CustomService>();
            return services;
        }
    }
}