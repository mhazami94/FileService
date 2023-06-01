using MediatR;

namespace FileService.Domain.SeekWork.Events;



public interface IDomainEvent : INotification
{
    DateTime CreatedAt { get; }
}
public abstract record class DomainEvent : Message, IDomainEvent
{
    public DateTime CreatedAt { get; init; }

    public DomainEvent()
    {
        CreatedAt = DateTime.Now;
    }
}
