using Microsoft.EntityFrameworkCore;
using OrderPaymentSystem.Domain.Entities;
using OrderPaymentSystem.Infrastructure.Messaging;

namespace OrderPaymentSystem.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        { }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OutboxMessage>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.Property(o => o.EventType)
                    .IsRequired();

                entity.Property(o => o.Payload)
                    .IsRequired();

                entity.Property(o => o.CreatedAt)
                    .IsRequired();

                entity.Property(o => o.Error)
                    .IsRequired(false);
            });
        }
    }
}
