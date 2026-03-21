using Microsoft.EntityFrameworkCore;
using ScrivenerSync.Domain.Entities;
using ScrivenerSync.Domain.Interfaces.Repositories;
using ScrivenerSync.Infrastructure.Persistence;

namespace ScrivenerSync.Infrastructure.Persistence.Repositories;

public class InvitationRepository(ScrivenerSyncDbContext db) : IInvitationRepository
{
    public async Task<Invitation?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        await db.Invitations.FindAsync([id], ct);

    public async Task<Invitation?> GetByTokenAsync(string token, CancellationToken ct = default) =>
        await db.Invitations.FirstOrDefaultAsync(i => i.Token == token, ct);

    public async Task<Invitation?> GetByUserIdAsync(Guid userId, CancellationToken ct = default) =>
        await db.Invitations.FirstOrDefaultAsync(i => i.UserId == userId, ct);

    public async Task AddAsync(Invitation invitation, CancellationToken ct = default) =>
        await db.Invitations.AddAsync(invitation, ct);
}
