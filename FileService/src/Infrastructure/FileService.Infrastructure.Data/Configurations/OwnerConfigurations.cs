using FileService.Domain.Owner;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileService.Infrastructure.Data.Configurations
{
    internal sealed class OwnerConfigurations : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owners", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(
                x => x.Value,
                x => new OwnerId(x));

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
