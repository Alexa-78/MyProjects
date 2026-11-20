# DiskSpaceMonitor

A Windows background service built with **.NET 10** that monitors available disk space, detects low-storage conditions, and stores disk usage measurements in a Microsoft SQL Server database.

## Overview

DiskSpaceMonitor is a lightweight monitoring application designed to run continuously as a Windows Service.

It automatically checks all available drives every five minutes, calculates the remaining free disk space, and logs warnings when a drive falls below a configurable threshold.

All collected measurements are stored in SQL Server using Entity Framework Core.

## Features

- **Automatic disk monitoring** – Checks all available and ready drives.
- **Periodic execution** – Performs disk checks every five minutes.
- **Low disk space detection** – Generates a warning when free disk space falls below 15%.
- **SQL Server integration** – Stores disk usage measurements in a database.
- **Entity Framework Core** – Handles database operations and data persistence.
- **Structured logging** – Uses Serilog for console and file logging.
- **Error handling** – Handles individual drive errors and monitoring exceptions.
- **Windows Service support** – Runs in the background without requiring an interactive console session.

## Technologies

| Technology | Purpose |
|---|---|
| C# | Programming language |
| .NET 10 | Application framework |
| Worker Service | Background processing |
| Entity Framework Core | Database access |
| Microsoft SQL Server | Data storage |
| Serilog | Application logging |
| Windows Services | Background execution |

## Project Structure

```text
DiskSpaceMonitor/
│
├── Data/
│   ├── MonitorDbContext.cs
│   └── DatabaseService.cs
│
├── Models/
│   └── DiskInfo.cs
│
├── Services/
│   └── DiskMonitor.cs
│
├── Migrations/
│
├── Worker.cs
├── Program.cs
├── appsettings.json
└── DiskSpaceMonitor.csproj
```

## How It Works

1. The Windows Service starts the background worker.
2. The worker triggers an initial disk space check.
3. DiskMonitor retrieves all available drives.
4. The application calculates the total size, available free space, and free space percentage.
5. If free space drops below 15%, a warning is logged.
6. The collected measurements are saved to SQL Server.
7. The process repeats every five minutes.

## Database

The application uses Microsoft SQL Server to store disk measurements.

Each measurement contains the following information:

| Property | Description |
|---|---|
| Id | Unique record identifier |
| DriveName | Name of the monitored drive |
| TotalSize | Total disk capacity in bytes |
| FreeSpace | Available free space in bytes |
| FreePercentage | Percentage of available free space |
| CheckedAt | Timestamp of the measurement (UTC) |

## Logging

DiskSpaceMonitor uses Serilog for structured application logging.

Log messages are written to:

- Console output
- Daily rolling log files

Example log output:

```text
Disk Space Monitor started.
Starting disk space check.
Drive C:\: 81.58% free
Disk space check completed. 1 drives checked.
```

When available free space falls below the configured threshold, a warning is generated.

## Requirements

- Windows 10 or Windows 11
- .NET 10
- Microsoft SQL Server
- SQL Server Management Studio (optional)
- Visual Studio 2022 or a compatible .NET development environment

## Configuration

Configure the SQL Server connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DiskSpaceMonitor;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Important:** Adjust the connection string to match your SQL Server installation. Do not commit passwords or sensitive connection details to GitHub.

## Installation

### 1. Clone the repository

```bash
git clone https://github.com/YOUR-USERNAME/DiskSpaceMonitor.git
cd DiskSpaceMonitor
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Create or update the database

```bash
dotnet ef database update
```

### 4. Build the application

```bash
dotnet build -c Release
```

### 5. Publish the application

```bash
dotnet publish -c Release -o "C:\Services\DiskSpaceMonitor"
```

### 6. Register the Windows Service

Open PowerShell as Administrator:

```powershell
New-Service `
    -Name "DiskSpaceMonitor" `
    -BinaryPathName "C:\Services\DiskSpaceMonitor\DiskSpaceMonitor.exe" `
    -DisplayName "Disk Space Monitor" `
    -Description "Monitors disk space and stores measurements in SQL Server." `
    -StartupType Automatic
```

### 7. Start the service

```powershell
Start-Service -Name "DiskSpaceMonitor"
```

### 8. Check the service status

```powershell
Get-Service -Name "DiskSpaceMonitor"
```

## Uninstallation

Stop and remove the Windows Service using PowerShell as Administrator:

```powershell
Stop-Service -Name "DiskSpaceMonitor"
sc.exe delete DiskSpaceMonitor
```

The published application files and database can be removed separately if they are no longer needed.

## Future Improvements

Potential future enhancements include:

- Configurable monitoring intervals and warning thresholds
- Email notifications for low disk space
- Automatic cleanup of historical measurements
- Additional monitoring metrics
- Improved monitoring dashboard
- Automated unit and integration tests

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

---

**DiskSpaceMonitor** – A lightweight Windows disk monitoring service built with C# and .NET 10.