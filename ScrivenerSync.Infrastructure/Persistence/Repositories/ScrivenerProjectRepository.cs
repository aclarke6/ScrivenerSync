using Microsoft.EntityFrameworkCore;
using ScrivenerSync.Domain.Entities;
using ScrivenerSync.Domain.Interfaces.Repositories;
using ScrivenerSync.Infrastructure.Persistence;

namespace ScrivenerSync.Infrastructure.Persistence.Repositories;

public class ScrivenerProjectRepository(ScrivenerSyncDbContext db) : IScrivenerProjectRepository
{
    public async Task<ScrivenerProject?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        await db.Projects.FindAsync([id], ct);

    public async Task<ScrivenerProject?> GetReaderActiveProjectAsync(CancellationToken ct = default) =>
        await db.Projects.FirstOrDefaultAsync(p => p.IsReaderActive && !p.IsSoftDeleted, ct);

    public async Task<IReadOnlyList<ScrivenerProject>> GetAllAsync(CancellationToken ct = default) =>
        await db.Projects.Where(p => !p.IsSoftDeleted).ToListAsync(ct);

    public async Task AddAsync(ScrivenerProject project, CancellationToken ct = default) =>
        await db.Projects.AddAsync(project, ct);
}
