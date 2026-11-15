using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentService.Domain.Entities;

namespace PaymentService.Infrastructure.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            // Primary Key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            // OrderId
            builder.Property(x => x.OrderId)
                .IsRequired();

            // Amount
            builder.Property(x => x.Amount)
                .HasPrecision(18, 2)
                .IsRequired();

            // CreatedAt
            builder.Property(x => x.CreatedAt)
                .IsRequired();

            // Index für OrderId
            builder.HasIndex(x => x.OrderId);
        }
    }
}
