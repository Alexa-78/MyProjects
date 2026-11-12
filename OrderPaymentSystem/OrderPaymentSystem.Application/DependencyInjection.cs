using Microsoft.Extensions.DependencyInjection;
using OrderPaymentSystem.Application.Interfaces;
using OrderPaymentSystem.Application.Services;

namespace OrderPaymentSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddScoped<IOrder, OrderService>();

            return services;
        }
    }
}