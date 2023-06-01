namespace FileService.Domain.SeekWork;


public interface IUnitOfWork
{
    Task<bool> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
}
