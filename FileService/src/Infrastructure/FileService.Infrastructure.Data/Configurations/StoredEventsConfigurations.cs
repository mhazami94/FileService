using FileService.Domain.SeekWork.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Infrastructure.Data.Configurations
{
    internal sealed class StoredEventsConfigurations : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.ToTable("StoredEvents", "dbo");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.CreatedAt)
            .IsRequired();

            builder.Property(r => r.ProcessedAt);

            builder.Property(r => r.MessageType)
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(r => r.Payload)
            .IsRequired();
        }
    }
}
