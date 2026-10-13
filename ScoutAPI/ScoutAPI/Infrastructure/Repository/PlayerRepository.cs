using Microsoft.EntityFrameworkCore;
using ScoutAPI.Application.Interfaces;
using ScoutAPI.Domain.Entities;
using ScoutAPI.Infrastructure.Entitiy_Framework_Core;

namespace ScoutAPI.Infrastructure.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ScoutContext _context;

        public PlayerRepository(ScoutContext context)
        {
            _context = context;
        }

        public async Task<Player?> GetPlayerAsync(int id)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Player> CreatePlayer(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            
            return player;
        }
    }
}
