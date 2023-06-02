using FileService.Domain;
using FileService.Domain.Files;
using FileService.Domain.Owner;
using FileService.Domain.SeekWork.Events;
using FileService.Domain.SeekWork;
using FileService.Infrastructure.Data;
using FileService.Infrastructure.Data.Context;
using FileService.Infrastructure.Events;

namespace FileService.Infrastructure.Domain
{
    public class FilesServiceUnitOfWork : UnitOfWork<FilesServiceContext>, IFilesServiceUnitOfWork
    {
        public IOwner Owners { get; }
        public IFiles Files { get; }
        private readonly IEventSerializer _eventSerializer;
        public FilesServiceUnitOfWork(FilesServiceContext dbContext,
            IOwner owners,
            IFiles files,
            IEventSerializer eventSerializer) : base(dbContext)
        {
            Owners = owners ?? throw new ArgumentNullException(nameof(owners));
            Files = files ?? throw new ArgumentNullException(nameof(files));
            _eventSerializer = eventSerializer ?? throw new ArgumentNullException(nameof(eventSerializer));
        }

        protected async override Task StoreEvents(CancellationToken cancellationToken)
        {
            var entities = DbContext.ChangeTracker.Entries()
                .Where(e => e.Entity is IAggregateRoot c && c.DomainEvents != null)
                .Select(e => e.Entity as IAggregateRoot)
                .ToArray();

            foreach (var entity in entities)
            {
                var messages = entity.DomainEvents
                    .Select(e => StoredEventHelper.BuildFromDomainEvent(e as DomainEvent, _eventSerializer))
                    .ToArray();

                entity.ClearDomainEvents();
                await DbContext.AddRangeAsync(messages, cancellationToken);
            }
        }
    }
}
