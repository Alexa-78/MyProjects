using DiskSpaceMonitor.Models;


namespace DiskSpaceMonitor.Services
{
    public class DiskMonitor
    {
        private readonly ILogger<DiskMonitor> _logger;

        public DiskMonitor(ILogger<DiskMonitor> logger)
        {
            _logger = logger;
        }

        public List<DiskInfo> CheckDisks()
        {
            var results = new List<DiskInfo>();

            foreach (var drive in DriveInfo.GetDrives())
            {
                try
                {
                    if (!drive.IsReady)
                        continue;

                    var totalSize = drive.TotalSize;
                    var freeSpace = drive.AvailableFreeSpace;

                    if (totalSize <= 0)
                        continue;

                    var freePercentage = (double)freeSpace / totalSize * 100;

                    var diskInfo = new DiskInfo
                    {
                        DriveName = drive.Name,
                        TotalSize = totalSize,
                        FreeSpace = freeSpace,
                        FreePercentage = freePercentage,
                        CheckedAt = DateTime.UtcNow
                    };

                    results.Add(diskInfo);

                    if (freePercentage < 15)
                    {
                        _logger.LogWarning(
                            "Low disk space on {Drive}: {FreePercentage:F2}%",
                            drive.Name,
                            freePercentage);
                    }
                    else
                    {
                        _logger.LogInformation(
                            "Drive {Drive}: {FreePercentage:F2}% free",
                            drive.Name,
                            freePercentage);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "An error occurred while checking drive {DriveName}.",
                        drive.Name);
                }
            }

            _logger.LogInformation(
                "Disk space check completed. {Count} drives checked.",
                results.Count);
 
            return results;
        }
    }
}
