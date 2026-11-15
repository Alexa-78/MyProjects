using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentService.Domain.Entities;

namespace PaymentService.Infrastructure.Data.Configurations
{
    public class ProcessedEventConfiguration : IEntityTypeConfiguration<ProcessedEvent>
    {
        public void Configure(EntityTypeBuilder<ProcessedEvent> builder)
        {
            builder.ToTable("ProcessedEvents");

            // Primary Key
            builder.HasKey(x => x.EventId);

            // EventId ist eindeutig
            builder.Property(x => x.EventId)
                .IsRequired();

            // Zeitpunkt der Verarbeitung
            builder.Property(x => x.ProcessedAt)
                .IsRequired();
        }
    }
}
