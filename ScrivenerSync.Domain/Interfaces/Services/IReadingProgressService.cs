using ScrivenerSync.Domain.Entities;

namespace ScrivenerSync.Domain.Interfaces.Services;

public interface IReadingProgressService
{
    Task RecordOpenAsync(Guid sectionId, Guid userId, CancellationToken ct = default);
    Task<bool> IsCaughtUpAsync(Guid userId, Guid projectId, CancellationToken ct = default);
    Task<IReadOnlyList<ReadEvent>> GetProgressForProjectAsync(Guid projectId, CancellationToken ct = default);
}
