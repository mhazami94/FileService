using FileService.Domain.SeekWork.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Domain.Owner.Events
{
    public record class OwnerUpdateEvent : DomainEvent
    {
        public OwnerId Id { get; init; }
        public string Name { get; init; }

        public OwnerUpdateEvent(OwnerId ownerId, string name)
        {
            Id = ownerId;
            Name = name;
            AggregateId = ownerId.Value;
        }
    }
}
