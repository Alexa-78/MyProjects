using DiskSpaceMonitor.Models;

namespace DiskSpaceMonitor.Data
{
    public class DatabaseService
    {
        private readonly MonitorDbContext _context;

        public DatabaseService(MonitorDbContext context)
        {
            _context = context;
        }

        public async Task SaveDiskInfosAsync(IEnumerable<DiskInfo> diskInfos, CancellationToken cancellationToken = default)
        {
            await _context.DiskInfos.AddRangeAsync(diskInfos, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
