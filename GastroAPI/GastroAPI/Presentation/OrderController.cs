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

        [HttpPost("create")]
        public async Task<ActionResult<Order>> CreateNewOrder([FromBody] AddToOrderRequest request)
        {
            var created = await _orderService.CreateOrderAsync(request.Product, request.Name);
            return CreatedAtAction(nameof(GetOrder), new { name = created.Name }, created);
        }



        [HttpPost("group/add")]
        public async Task<ActionResult<Order>> AddToOrderGroup([FromBody] AddToOrderRequest request)
        {
            var order = await _orderService.AddToOrderGroupAsync(request.Product, request.Name);
            return Ok(order);
        }

        [HttpGet("group/{name}")]
        public async Task<ActionResult<Order>> GetOrderGroup(string name)
        {
            var order = await _orderService.GetOrderGroupAsync(name);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost("group/create")]
        public async Task<ActionResult<Order>> CreateNewOrderGroup([FromBody] AddToOrderRequest request)
        {
            var created = await _orderService.CreateOrderGroupAsync(request.Product, request.Name);
            return CreatedAtAction(nameof(GetOrder), new { name = created.Name }, created);
        }
    }
}
