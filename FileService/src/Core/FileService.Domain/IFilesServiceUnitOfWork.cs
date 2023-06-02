using FileService.Domain.Files;
using FileService.Domain.Owner;
using FileService.Domain.SeekWork;

namespace FileService.Domain
{
    public interface IFilesServiceUnitOfWork : IUnitOfWork
    {
        IOwner Owners { get; }
        IFiles Files { get; }
    }
}
