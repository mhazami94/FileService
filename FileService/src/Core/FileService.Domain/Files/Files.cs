using FileService.Domain.Files.Events;
using FileService.Domain.SeekWork;

namespace FileService.Domain.Files;

public class Files : AggregateRoot<FilesId>
{
    public string FileName { get; private set; }
    public string ContentType { get; private set; }
    public byte[] Content { get; private set; }
    public float Size { get; private set; }
    public string Extension { get; private set; }
    public DateTime CreatAt { get; private set; } = DateTime.Now;
    public DateTime? LastUpdate { get; private set; }


    public static Files CreateNew(string fileName, string contentType, byte[] content, float size, string extension)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        if (string.IsNullOrEmpty(contentType))
            throw new ArgumentNullException(nameof(contentType));
        if (content == null)
            throw new ArgumentNullException(nameof(content));
        if (string.IsNullOrEmpty(extension))
            throw new ArgumentNullException(nameof(extension));
        if (size == 0)
            throw new ArgumentNullException(nameof(size));

        var id = new FilesId(Guid.NewGuid());
        return new Files(id, fileName, contentType, content, size, extension);
    }

    public void UpdateFile(string fileName, string contentType, byte[] content, float size, string extension)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        if (string.IsNullOrEmpty(contentType))
            throw new ArgumentNullException(nameof(contentType));
        if (content == null)
            throw new ArgumentNullException(nameof(content));
        if (string.IsNullOrEmpty(extension))
            throw new ArgumentNullException(nameof(extension));
        if (size == 0)
            throw new ArgumentNullException(nameof(size));

        FileName = fileName;
        ContentType = contentType;
        Content = content;
        Size = size;
        Extension = extension;
        AddDomainEvent(new FilesUpdatedEvent(Id, FileName, ContentType, Content, Size, Extension));
    }

    public Files(FilesId id, string fileName, string contentType, byte[] content, float size, string extension)
    {
        Id = id;
        FileName = fileName;
        ContentType = contentType;
        Content = content;
        Size = size;
        Extension = extension;
        CreatAt = DateTime.Now;
    }

}
