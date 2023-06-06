using FileService.Domain.Owner;
using FileService.Domain.SeekWork;
using FileService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FileService.Infrastructure.Domain.Owner
{
    public class OwnersManager : IOwner
    {
        private readonly FilesServiceContext _context;

        public OwnersManager(FilesServiceContext context)
        {
            _context = context;
        }
        public async Task Add(FileService.Domain.Owner.Owner owner, CancellationToken cancellationToken = default)
        {
            await _context.Owners.AddAsync(owner, cancellationToken);
        }

        public async Task<IReadOnlyList<FileService.Domain.Owner.Owner>> Filter(Specification<FileService.Domain.Owner.Owner> specification, CancellationToken cancellationToken = default)
        {
            return await _context.Owners
                 .Where(specification.ToExpression())
                 .ToListAsync(cancellationToken);
        }

        public async Task<FileService.Domain.Owner.Owner?> GetByEmail(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Owners
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<FileService.Domain.Owner.Owner?> GetById(OwnerId ownerId, CancellationToken cancellationToken = default)
        {
            return await _context.Owners
                 .FindAsync(ownerId, cancellationToken);
        }
    }
}
