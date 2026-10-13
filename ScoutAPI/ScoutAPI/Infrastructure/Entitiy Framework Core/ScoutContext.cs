using Microsoft.EntityFrameworkCore;
using ScoutAPI.Domain.Entities;

namespace ScoutAPI.Infrastructure.Entitiy_Framework_Core
{
    public class ScoutContext : DbContext
    {
        public ScoutContext(DbContextOptions<ScoutContext> options)
            : base(options)
        { }
        public DbSet<Player> Players { get; set; }
    }
}
