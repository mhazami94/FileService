using FileService.Domain.Files;
using FileService.Domain.Owner;
using FileService.Domain.SeekWork.Events;
using Microsoft.EntityFrameworkCore;

namespace FileService.Infrastructure.Data.Context
{
    public sealed class FilesServiceContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<StoredEvent> StoredEvents { get; set; }

        public FilesServiceContext(DbContextOptions<FilesServiceContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FilesServiceContext).Assembly);
        }
    }
}
