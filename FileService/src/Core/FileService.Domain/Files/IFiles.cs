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
        Task Add(Files file, CancellationToken cancellationToken = default);
        Task<Files?> GetById(FilesId filesId, CancellationToken cancellationToken = default);
        void Remove(FilesId filesId);
        Task<IReadOnlyList<Files>> GetGroupFiles(List<FilesId> filesIds, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Files>> Filter(Specification<Files> specification, CancellationToken cancellationToken = default);
    }
}
