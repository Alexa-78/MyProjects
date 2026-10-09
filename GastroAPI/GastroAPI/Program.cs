using GastroAPI.Infrastructure.Entity_Framework_Core;
using Microsoft.EntityFrameworkCore;
using GastroAPI.Application.Interfaces;
using GastroAPI.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

// für EF Core (DBContext)
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GastroContext>(options =>
    options.UseSqlServer(connectionstring,sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null
            );
        }
    ));


var app = builder.Build();

//sichergehen das DB existiert ansonst erstellen
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GastroContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Run();

