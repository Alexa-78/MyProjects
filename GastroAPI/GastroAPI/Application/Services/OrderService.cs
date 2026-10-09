using GastroAPI.Application.Interfaces;
using GastroAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order?> AddToOrderAsync(Product product, string name)
        {
            return await _repository.AddToOrderAsync(product, name);
        }

        public async Task<Order> GetOrderAsync(string name)
        { 
            return await _repository.GetOrderAsync(name);
        }

        public async Task<Order> CreateOrderAsync(Product product, string name)
        {
            return await _repository.CreateOrderAsync(product, name);
        }

        public async Task<Order?> AddToOrderGroupAsync(Product product, string group)
        {
            return await _repository.AddToOrderGroupAsync(product, group);
        }

        public async Task<Order> GetOrderGroupAsync(string group)
        {
            return await _repository.GetOrderGroupAsync(group);
        }

        public async Task<Order> CreateOrderGroupAsync(Product product, string group)
        {
            return await _repository.CreateOrderGroupAsync(product, group);
        }
    }
}
