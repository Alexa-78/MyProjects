using Microsoft.AspNetCore.Mvc;
using OrderPaymentSystem.Application.DTOs;
using OrderPaymentSystem.Application.Interfaces;
using OrderPaymentSystem.Domain.Entities;

namespace OrderPaymentSystem.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrder _orderService;
        public OrderController(IOrder orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateNewOrder([FromBody]CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderService.CreateNewOrder(request, cancellationToken);

            if (order == null)
                return BadRequest("Ungültige Bestellsumme.");

            return CreatedAtAction(nameof(GetOrder),new { id = order.Id },order);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrder(id, cancellationToken);

            if (order == null) 
                return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders(CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetAllOrders(cancellationToken);
            return Ok(orders);
        }

        [HttpPatch("{id:guid}/status")]
        public async Task<ActionResult<Order>> UpdateOrderStatus(Guid id, [FromBody]UpdateOrderStatusRequest request, CancellationToken cancellationToken)
        {
            var updated = await _orderService.UpdateOrderStatus(id, request.Status, cancellationToken);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
    }
}
