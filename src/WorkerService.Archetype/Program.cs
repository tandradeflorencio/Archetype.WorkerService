using Serilog;
using WorkerService.Archetype;
using WorkerService.Archetype.Configurations;

const string LogPrefix = $"{ConstantsUtil.LogPrefix}";

try
{
    Log.Information($"{LogPrefix} {nameof(Program)} The application is starting.");

    IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(hostContext.HostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

        IConfiguration configuration = builder.Build();

        services.ConfigureDependencies(configuration);
        services.ConfigureLogs();
        services.ConfigureHealthChecks();
        services.AddHostedService<Worker>();
    })
    .UseSerilog((hostingContext, loggerConfig) => loggerConfig
        .ReadFrom.Configuration(hostingContext.Configuration)
        .Enrich.WithProperty("WorkerService.Archetype", "WorkerService.Archetype")
        .WriteTo.ApplicationInsights(hostingContext?.Configuration.GetConnectionString("ApplicationInsights"), TelemetryConverter.Events)
    )
    .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, $"{LogPrefix} {nameof(Program)} Fatal error. The application is shutting down.");
}
finally
{
    Log.Information($"{LogPrefix} {nameof(Program)} The application is shutting down.");
    Log.CloseAndFlush();
}