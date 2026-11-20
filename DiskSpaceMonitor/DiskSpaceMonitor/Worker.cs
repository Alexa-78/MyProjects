using DiskSpaceMonitor.Data;
using DiskSpaceMonitor.Services;

namespace DiskSpaceMonitor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly DiskMonitor _diskMonitor;
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, DiskMonitor diskMonitor, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _diskMonitor = diskMonitor;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Disk Space Monitor started.");

            using var timer = new PeriodicTimer(TimeSpan.FromMinutes(5));

            try
            {
                do
                {
                    try
                    {
                        _logger.LogInformation("Starting disk space check.");

                        var diskInfos = _diskMonitor.CheckDisks();

                        await using var scope = _scopeFactory.CreateAsyncScope();

                        var databaseService = scope.ServiceProvider.GetRequiredService<DatabaseService>();

                        await databaseService.SaveDiskInfosAsync(diskInfos, stoppingToken);

                        _logger.LogInformation("{Count} disk records saved successfully.", diskInfos.Count);
                    }
                    catch (OperationCanceledException)
                        when (stoppingToken.IsCancellationRequested)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error while monitoring disks.");
                    }

                } while (await timer.WaitForNextTickAsync(stoppingToken));
            }
            catch (OperationCanceledException)
                when (stoppingToken.IsCancellationRequested)
            {
                // Expected when the application is shutting down.
            }

            _logger.LogInformation("Disk Space Monitor stopped.");
        }
    }
}
