using Microsoft.AspNetCore.Mvc;
using ScoutAPI.Application.Services;
using ScoutAPI.Application.DTOs;
using ScoutAPI.Domain.Entities;

namespace ScoutAPI.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly PlayerService _playerService;
        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var product = await _playerService.GetPlayerAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> Create([FromBody] CreatePlayerRequest request)
        {
            var player = new Player(request.Name);

            var created = await _playerService.CreatePlayer(player);
            return CreatedAtAction(nameof(GetPlayer), new { id = created.Id }, created);
        }
    }
}
