using Microsoft.EntityFrameworkCore;
using OrderAPI.Application.DTOs;
using OrderAPI.Application.Interfaces;
using OrderAPI.Domain.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Application.Services
{
    public class OrderService : IOrder
    {
        private readonly OrderContext _orderContext;
        private readonly ILogger<OrderService> _logger;

        public OrderService(OrderContext orderContext, ILogger<OrderService> logger)
        {
            _orderContext = orderContext;
            _logger = logger;
        }

        public async Task<Order?> CreateNewOrder(CreateOrderRequest orderRequest)
        {
            try
            {
                Order orderItem = new Order(orderRequest);
                orderItem.SetOrderStatus(OrderStatus.Created);

                if (!orderItem.CheckOrderSum())
                    return null;

                _orderContext.Orders.Add(orderItem);
                await _orderContext.SaveChangesAsync();
                return orderItem;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex,
                    "Datenbankfehler beim Erstellen einer Bestellung.");

                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Unerwarteter Fehler beim Erstellen einer Bestellung.");

                throw;
            }
        }
        public async Task<Order?> GetOrder(Guid orderid)
        {
            try
            {
                return await _orderContext.Orders.FirstOrDefaultAsync(o => o.Id == orderid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Fehler beim Abrufen der Bestellung {OrderId}",
                    orderid);

                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                return await _orderContext.Orders.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Fehler beim Abrufen aller Bestellungen.");

                throw;
            }
        }
        public async Task<Order?> UpdateOrderStatus(Guid id, OrderStatus status)
        {
            try
            {
                Order order = await _orderContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

                if (order == null)
                    return null;

                order.SetOrderStatus(status);
                await _orderContext.SaveChangesAsync();

                return order;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex,
                    "Datenbankfehler beim Aktualisieren der Bestellung {OrderId}",
                    id);

                throw;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex,
                    "Ungültiger Statuswechsel bei Bestellung {OrderId}",
                    id);

                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Unerwarteter Fehler beim Aktualisieren der Bestellung {OrderId}",
                    id);

                throw;
            }
        }
    }
}
