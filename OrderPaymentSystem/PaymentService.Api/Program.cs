using Microsoft.EntityFrameworkCore;
using PaymentService.Application.Interfaces;
using PaymentService.Application.Payments;
using PaymentService.Infrastructure.Data;
using PaymentService.Infrastructure.Messaging;
using PaymentService.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Datenbank konfigurieren
builder.Services.AddDbContext<PaymentContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PaymentDatabase")));

// Services registrieren
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ProcessOrderPaymentHandler>();
builder.Services.AddHostedService<OrderCreatedConsumer>();

var app = builder.Build();

//// HTTP-Pipeline
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();