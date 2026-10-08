using GastroAPI.Application.DTOs;
using GastroAPI.Application.Services;
using GastroAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GastroAPI.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> AddToOrder([FromBody] AddToOrderRequest request)
        {
            var order = await _orderService.AddToOrderAsync(request.Product, request.Name);
            return Ok(order);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Order>> GetOrder(string name)
        {
            var order = await _orderService.GetOrderAsync(name);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateNewOrder([FromBody] Product product, string name)
        {
            var created = await _orderService.CreateOrderAsync(product, name);
            return CreatedAtAction(nameof(GetOrder), new { name = created.Name }, created);
        }
    }
}
