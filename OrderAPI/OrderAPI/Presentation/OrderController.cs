using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Application.DTOs;
using OrderAPI.Application.Interfaces;
using OrderAPI.Application.Services;
using OrderAPI.Domain.Entities;

namespace OrderAPI.Presentation
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
        public async Task<ActionResult<Order>> CreateNewOrder([FromBody]CreateOrderRequest request)
        {
            var order = await _orderService.CreateNewOrder(request);

            if (order == null)
                return BadRequest("Ungültige Bestellsumme.");

            return CreatedAtAction(nameof(GetOrder),new { id = order.Id },order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrder(id);

            if (order == null) 
                return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult<Order>> UpdateOrderStatus(Guid id, [FromBody]UpdateOrderStatusRequest request)
        {
            var updated = await _orderService.UpdateOrderStatus(id, request.Status);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
    }
}
