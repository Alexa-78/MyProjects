using ScoutAPI.Domain.Entities;

namespace ScoutAPI.Application.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player> CreatePlayer(Player player);
    }
}
