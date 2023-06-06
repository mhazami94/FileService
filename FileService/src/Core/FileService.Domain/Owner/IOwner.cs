using FileService.Domain.SeekWork;

namespace FileService.Domain.Owner;

public interface IOwner : IRepository<Owner>
{
    Task Add(Owner owner, CancellationToken cancellationToken = default);
    Task<Owner?> GetById(OwnerId ownerId, CancellationToken cancellationToken = default);
    Task<Owner?> GetByEmail(string email, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Owner>> Filter(Specification<Owner> specification, CancellationToken cancellationToken = default);
}
