using System;
using System.Collections.Generic;
using System.Text;

namespace DiskSpaceMonitor.Models
{
    public class DiskInfo
    {
        public int Id { get; set; }

        public string DriveName { get; set; } = string.Empty;

        public long TotalSize { get; set; }

        public long FreeSpace { get; set; }

        public double FreePercentage { get; set; }

        public DateTime CheckedAt { get; set; }
    }
}
