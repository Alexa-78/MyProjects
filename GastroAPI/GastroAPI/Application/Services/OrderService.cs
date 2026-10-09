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

        public async Task<Order?> AddToOrderAsync(int productId, string name)
        {
            return await _repository.AddToOrderAsync(productId, name);
        }

        public async Task<Order> GetOrderAsync(string name)
        { 
            return await _repository.GetOrderAsync(name);
        }

        public async Task<Order> CreateOrderAsync(int productId, string name)
        {
            return await _repository.CreateOrderAsync(productId, name);
        }

        public async Task<Order?> AddToOrderGroupAsync(int productId, string group)
        {
            return await _repository.AddToOrderGroupAsync(productId, group);
        }

        public async Task<Order> GetOrderGroupAsync(string group)
        {
            return await _repository.GetOrderGroupAsync(group);
        }

        public async Task<Order> CreateOrderGroupAsync(int productId, string group)
        {
            return await _repository.CreateOrderGroupAsync(productId, group);
        }
    }
}
