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

        [HttpPost("add")]
        public async Task<ActionResult<Order>> AddToOrder([FromBody] AddToOrderRequest request)
        {
            var order = await _orderService.AddToOrderAsync(request.ProductId, request.Name);
            return Ok(order);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Order>> GetOrder(string name)
        {
            var order = await _orderService.GetOrderAsync(name);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Order>> CreateNewOrder([FromBody] AddToOrderRequest request)
        {
            var created = await _orderService.CreateOrderAsync(request.ProductId, request.Name);
            return CreatedAtAction(nameof(GetOrder), new { name = created.Name }, created);
        }

        [HttpPost("group/add")]
        public async Task<ActionResult<Order>> AddToOrderGroup([FromBody] AddToOrderGroupRequest request)
        {
            var order = await _orderService.AddToOrderGroupAsync(request.ProductId, request.Group);
            return Ok(order);
        }

        [HttpGet("group/{name}")]
        public async Task<ActionResult<Order>> GetOrderGroup(string group)
        {
            var order = await _orderService.GetOrderGroupAsync(group);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost("group/create")]
        public async Task<ActionResult<Order>> CreateNewOrderGroup([FromBody] AddToOrderGroupRequest request)
        {
            var created = await _orderService.CreateOrderGroupAsync(request.ProductId, request.Group);
            return CreatedAtAction(nameof(GetOrder), new { name = created.Name }, created);
        }
    }
}
