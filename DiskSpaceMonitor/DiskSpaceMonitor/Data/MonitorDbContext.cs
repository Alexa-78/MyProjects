using Microsoft.EntityFrameworkCore;
using DiskSpaceMonitor.Models;
using DiskSpaceMonitor.Services;

namespace DiskSpaceMonitor.Data
{
    public class MonitorDbContext : DbContext
    {
        public MonitorDbContext(DbContextOptions<MonitorDbContext> options)
           : base(options)
        { }
        public DbSet<DiskInfo> DiskInfos { get; set; }
    }
}
