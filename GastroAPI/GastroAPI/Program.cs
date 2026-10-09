using GastroAPI.Application.Interfaces;
using GastroAPI.Application.Services;
using GastroAPI.Infrastructure.Entity_Framework_Core;
using GastroAPI.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;    //jwt
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;   //jwt
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductService>();

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


//jwt token code
builder.Services
.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    var jwt = builder.Configuration.GetSection("Jwt");
    var key = jwt["Key"]
    ?? throw new InvalidOperationException("JWT-Key fehlt.");

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwt["Issuer"],

        ValidateAudience = true,
        ValidAudience = jwt["Audience"],

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key))
    };
});

builder.Services.AddAuthorization();
//ende jwt token code


var app = builder.Build();

//sichergehen das DB existiert ansonst erstellen
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GastroContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication(); //jwt token, muss vor authorization stehen !!!!
app.UseAuthorization();

app.MapControllers();

app.Run();

