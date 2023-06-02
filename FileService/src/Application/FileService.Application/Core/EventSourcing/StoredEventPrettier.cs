﻿using FileService.Application.Core.EventSourcing.StoredEventsData;
using FileService.Domain.SeekWork.Events;
using Newtonsoft.Json;

namespace FileService.Application.Core.EventSourcing;

public static class StoredEventPrettier<THistoryData>
    where THistoryData : StoredEventData, new()
{
    public static List<THistoryData> ToPretty(IList<StoredEvent> messages)
    {
        List<THistoryData> historyData = new List<THistoryData>();

        foreach (var message in messages)
        {
            var eventName = message.MessageType
                .Substring(message.MessageType.LastIndexOf('.')).Substring(1);

            THistoryData history = JsonConvert
                .DeserializeObject<THistoryData>(message.Payload);

            history.Id = message.Id.ToString();
            history.Timestamp = message
                .CreatedAt.ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");
            history.Action = eventName;
            historyData.Add(history);
        }

        return historyData;
    }
}
