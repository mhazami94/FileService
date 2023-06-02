
using FileService.Domain.Files;
using FileService.Domain.Owner;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileService.Infrastructure.Data.Configurations
{
    internal sealed class FilesConfigurations : IEntityTypeConfiguration<Files>
    {
        public void Configure(EntityTypeBuilder<Files> builder)
        {
            builder.ToTable("Files", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(
                x => x.Value,
                x => new FilesId(x));

            builder.Property(x => x.FileName)
                .HasColumnType("varchar(128)")
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(x => x.ContentType)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Content)
                .HasColumnType("varbinary(MAX)")
                .IsRequired();

            builder.Property(x => x.Extension)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Size)
                .HasColumnType("float")
                .IsRequired();

            builder.Property<DateTime>(x => x.CreatAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property<DateTime?>(x => x.LastUpdate)
                .HasColumnType("datetime");

            builder.Property(x => x.IsPrivate)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.OwnerId)
                .HasConversion(
                x => x.Value,
                x => new OwnerId(x))
                .IsRequired();
        }
    }
}
