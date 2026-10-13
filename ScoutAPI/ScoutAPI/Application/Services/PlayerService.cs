using Microsoft.EntityFrameworkCore;
using ScoutAPI.Application.Interfaces;
using ScoutAPI.Domain.Entities;

namespace ScoutAPI.Application.Services
{
    public class PlayerService
    {
        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Player?> GetPlayerAsync(int id)
        {
            return await _repository.GetPlayerAsync(id);
        }
        public async Task<Player> CreatePlayer(Player player)
        { 
            return await _repository.CreatePlayer(player);
        }
    }
}
