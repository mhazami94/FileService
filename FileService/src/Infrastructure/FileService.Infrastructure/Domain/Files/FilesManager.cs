using FileService.Domain.Files;
using FileService.Domain.SeekWork;
using FileService.Infrastructure.Data.Context;
using FileService.Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;

namespace FileService.Infrastructure.Domain.Files
{
    public class FilesManager : IFiles
    {
        private readonly FilesServiceContext _context;

        public FilesManager(FilesServiceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Add(FileService.Domain.Files.Files file, CancellationToken cancellationToken = default)
        {
            await _context.Files.AddAsync(file, cancellationToken);
        }

        public async Task<IReadOnlyList<FileService.Domain.Files.Files>> Filter(Specification<FileService.Domain.Files.Files> specification, CancellationToken cancellationToken = default)
        {
            return await _context.Files
                .Where(specification.ToExpression())
                .ToListAsync();
        }

        public async Task<FileService.Domain.Files.Files?> GetById(FilesId filesId, CancellationToken cancellationToken = default)
        {
            return await _context.Files.FindAsync(filesId, cancellationToken);
        }

        public async Task<IReadOnlyList<FileService.Domain.Files.Files>> GetGroupFiles(List<FilesId> filesIds, CancellationToken cancellationToken = default)
        {
            return await _context.Files
                .Where(x => x.Id.In(filesIds))
                .ToListAsync();
        }

        public void Remove(FilesId filesId)
        {
            var file = FileService.Domain.Files.Files.CreateNewForDelete(filesId);
            _context.Files.Remove(file);
        }
    }
}
