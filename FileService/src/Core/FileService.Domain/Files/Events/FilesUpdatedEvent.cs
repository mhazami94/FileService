using FileService.Domain.SeekWork.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Domain.Files.Events
{
    public record class FilesUpdatedEvent : DomainEvent
    {
        public FilesId Id { get; init; }
        public string FileName { get; private set; }
        public string ContentType { get; private set; }
        public byte[] Content { get; private set; }
        public float Size { get; private set; }
        public string Extension { get; private set; }
        public DateTime? LastUpdate { get; private set; }

        public FilesUpdatedEvent(FilesId id, string fileName, string contentType, byte[] content, float size, string extension)
        {

            Id = id;
            FileName = fileName;
            ContentType = contentType;
            Content = content;
            Size = size;
            Extension = extension;
            LastUpdate = DateTime.Now;
            AggregateId = id.Value;
        }
    }
}
