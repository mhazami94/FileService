using FileService.Domain.SeekWork.Events;

namespace FileService.Domain.SeekWork;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}
