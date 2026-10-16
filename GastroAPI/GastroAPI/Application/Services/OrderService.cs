using GastroAPI.Application.Interfaces;
using GastroAPI.Domain.Entities;

namespace GastroAPI.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderedProductsRepository _orderedProductsRepository;
        private readonly IProductRepository _productRepository;


        public OrderService(IOrderRepository orderRepository, IOrderedProductsRepository orderedProductsRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderedProductsRepository = orderedProductsRepository;
            _productRepository = productRepository;
        }

        public async Task<Order?> AddToOrderAsync(int productId, string name)
        {
            var product = await _productRepository.GetProductAsync(productId);

            if (product == null)
                return null;

            var order = await _orderRepository.GetOrderAsync(name); 

            if (order == null)
                return null;

            var orderedproduct = new OrderedProducts(
                            order.Id,
                            product.Number,
                            product.Name,
                            product.Price);

            await _orderedProductsRepository.AddProductAsync(orderedproduct);

            return order;
        }

        public async Task<Order> GetOrderAsync(string name)
        { 
            return await _orderRepository.GetOrderAsync(name);
        }

        public async Task<Order> CreateOrderAsync(int productId, string name)
        {
            var product = await _productRepository.GetProductAsync(productId);

            if (product == null)
                return null;

            Order order = new Order();
            order.SetName(name);

            await _orderRepository.CreateOrderAsync(order);

            if (order == null)
                return null;

            var orderedproduct = new OrderedProducts(
                            order.Id,
                            product.Number,
                            product.Name,
                            product.Price);

            await _orderedProductsRepository.AddProductAsync(orderedproduct);

            return order;
        }

        public async Task<Order?> AddToOrderGroupAsync(int productId, string group)
        {
            var product = await _productRepository.GetProductAsync(productId);

            if (product == null)
                return null;

            var order = await _orderRepository.GetOrderAsync(group);

            if (order == null)
                return null;

            var orderedproduct = new OrderedProducts(
                            order.Id,
                            product.Number,
                            product.Name,
                            product.Price);

            await _orderedProductsRepository.AddProductAsync(orderedproduct);

            return order;
        }

        public async Task<Order> GetOrderGroupAsync(string group)
        {
            return await _orderRepository.GetOrderGroupAsync(group);
        }

        public async Task<Order> CreateOrderGroupAsync(int productId, string group)
        {
            var product = await _productRepository.GetProductAsync(productId);

            if (product == null)
                return null;

            Order order = new Order();
            order.SetGroup(group);

            await _orderRepository.CreateOrderGroupAsync(order);

            if (order == null)
                return null;

            var orderedproduct = new OrderedProducts(
                            order.Id,
                            product.Number,
                            product.Name,
                            product.Price);

            await _orderedProductsRepository.AddProductAsync(orderedproduct);

            return order;
        }
    }
}
