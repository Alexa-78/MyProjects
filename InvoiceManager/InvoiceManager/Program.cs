using InvoiceManager.Data;
using InvoiceManager.Forms;
using InvoiceManager.Interfaces;
using InvoiceManager.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InvoiceManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<InvoiceContext>(options =>
                    options.UseSqlite("Data Source=invoice.db"));

                services.AddScoped<IEmailService, EmailService>();
                services.AddScoped<IInvoiceService, InvoiceService>();
                services.AddScoped<IPDFService, PDFService>();
                services.AddScoped<ICustomerService, CustomerService>();
                services.AddScoped<IProductService, ProductService>();

                services.AddTransient<MainForm>();
                services.AddTransient<CustomerForm>();
                services.AddTransient<ProductForm>();
                services.AddTransient<InvoiceForm>();
                services.AddTransient<SettingsForm>();
            })
            .Build();

            using var scope = host.Services.CreateScope();
            // Wenn die Datenbank noch nicht existiert, wird sie automatisch erstellt.
            var context = scope.ServiceProvider.GetRequiredService<InvoiceContext>();
            context.Database.EnsureCreated();

            var mainForm = scope.ServiceProvider.GetRequiredService<MainForm>();

            Application.Run(mainForm);
        }
    }
}