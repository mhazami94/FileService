using FileService.Domain.SeekWork;

namespace FileService.Domain.Files;

public class FilesId : StronglyTypedId<FilesId>
{
    public FilesId(Guid value) : base(value)
    {
    }
}
