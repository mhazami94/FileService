using FileService.Domain.SeekWork.Events;
using FileService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace FileService.Infrastructure.Events;

public interface IStoredEvents
{
    void UpdateProcessedAt(StoredEvent message);
    Task StoreRange(List<StoredEvent> messages);
    Task<IList<StoredEvent>> GetByAggregateId(Guid aggregateId, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<StoredEvent>> FetchUnprocessed(int batchSize, CancellationToken cancellationToken);
}

public class StoredEvents : IStoredEvents
{
    private readonly FilesServiceContext _dbContext;

    public StoredEvents(FilesServiceContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void UpdateProcessedAt(StoredEvent message)
    {
        _dbContext.StoredEvents.Update(message);
    }

    public async Task StoreRange(List<StoredEvent> messages)
    {
        await _dbContext.StoredEvents.AddRangeAsync(messages);
    }

    public async Task<IList<StoredEvent>> GetByAggregateId(Guid aggregateId, CancellationToken cancellationToken)
    {
        var results = await _dbContext.StoredEvents
            .Where(c => c.AggregateId == aggregateId)
            .OrderBy(m => m.CreatedAt)
            .ToListAsync(cancellationToken);

        return results;
    }

    public async Task<IReadOnlyCollection<StoredEvent>> FetchUnprocessed(int batchSize, CancellationToken cancellationToken)
    {
        var results = await _dbContext.StoredEvents
            .Where(m => null == m.ProcessedAt)
            .OrderBy(m => m.CreatedAt)
            .Take(batchSize)
            .ToArrayAsync(cancellationToken);

        return results.ToImmutableArray();
    }
}