using OrderPaymentSystem.Application.DTOs;
using OrderPaymentSystem.Application.Interfaces;
using OrderPaymentSystem.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace OrderPaymentSystem.Application.Services
{
    public class OrderService : IOrder
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<Order?> CreateNewOrder(CreateOrderRequest orderRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                var order = new Order(
                    orderRequest.CustomerEmail,
                    orderRequest.TotalAmount
                );

                if (!order.CheckOrderSum())
                    return null;

                return await _orderRepository.CreateAsync(order, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler beim Erstellen einer Bestellung.");

                throw;
            }
        }

        public async Task<Order?> GetOrder(Guid orderId, CancellationToken cancellationToken = default)
        {
            return await _orderRepository.GetByIdAsync(orderId, cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetAllOrders(CancellationToken cancellationToken = default)
        {
            return await _orderRepository.GetAllAsync(cancellationToken);
        }

        public async Task<Order?> UpdateOrderStatus(Guid id, OrderStatus status, CancellationToken cancellationToken = default)
        {
            var order = await _orderRepository.GetByIdAsync(id, cancellationToken);

            if (order == null)
                return null;

            order.SetOrderStatus(status);

            await _orderRepository.SaveChangesAsync(cancellationToken);

            return order;
        }
    }
}