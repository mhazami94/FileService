using FileService.Domain.SeekWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Domain.Files
{
    public interface IFiles : IRepository<Files>
    {
        Task<Files> Add(Files file, CancellationToken cancellationToken = default);
        Task<Files> GetById(FilesId filesId, CancellationToken cancellationToken = default);
        Task<bool> Remove(FilesId filesId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Files>> GetGroupFiles(List<FilesId> filesIds, CancellationToken cancellationToken = default);
    }
}
