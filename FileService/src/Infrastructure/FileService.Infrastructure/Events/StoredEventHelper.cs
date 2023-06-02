﻿using FileService.Domain.Owner.Events;
using FileService.Domain.SeekWork.Events;
using MediatR;
using Newtonsoft.Json;
using System.Reflection;

namespace FileService.Infrastructure.Events;

public static class StoredEventHelper
{
    public static StoredEvent BuildFromDomainEvent<TE>(TE @event, IEventSerializer serializer)
        where TE : DomainEvent
    {
        if (null == @event)
            throw new ArgumentNullException(nameof(@event));

        if (null == serializer)
            throw new ArgumentNullException(nameof(serializer));

        var type = @event.GetType().FullName;
        return new StoredEvent(@event, serializer.Serialize(@event));
    }

    public static T Deserialize<T>(StoredEvent message) where T : class, INotification
    {
        var type = GetEventType(message.MessageType);
        return JsonConvert.DeserializeObject(message.Payload, type) as T;
    }

    public static Type GetEventType(string messageType)
    {
        Type type = Assembly.GetAssembly(typeof(OwnerUpdateEvent)).GetType(messageType);
        return type;
    }
}
