namespace demoapi.HostedService;

public class InitializationService : IHostedService
{
    private ILogger<InitializationService> _logger;
    public InitializationService(ILogger<InitializationService> logger)
    {
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken ct)
    {
       _logger.LogInformation("app starting");
    }

    public async Task StopAsync(CancellationToken ct)
    {
       _logger.LogInformation("app stopped");
    }
}