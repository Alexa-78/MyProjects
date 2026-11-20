using DiskSpaceMonitor;
using DiskSpaceMonitor.Data;
using DiskSpaceMonitor.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.Extensions.Hosting;

// Configure log directory
var logDirectory = Path.Combine(
    AppContext.BaseDirectory,
    "Logs");

Directory.CreateDirectory(logDirectory);

// Create application builder
var builder = Host.CreateApplicationBuilder(args);

// Configure Windows Service
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "DiskSpaceMonitor";
});

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        Path.Combine(logDirectory, "diskmonitor-.log"),
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Services.AddSerilog();


builder.Services.AddSingleton<DiskMonitor>();
builder.Services.AddScoped<DatabaseService>();
builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContext<MonitorDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var host = builder.Build();

try
{
    Log.Information("DiskSpaceMonitor is starting.");
    host.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "DiskSpaceMonitor terminated unexpectedly.");
}
finally
{
    Log.CloseAndFlush();
}
