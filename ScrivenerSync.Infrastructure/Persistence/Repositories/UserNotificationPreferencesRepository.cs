using Microsoft.EntityFrameworkCore;
using ScrivenerSync.Domain.Entities;
using ScrivenerSync.Domain.Interfaces.Repositories;
using ScrivenerSync.Infrastructure.Persistence;

namespace ScrivenerSync.Infrastructure.Persistence.Repositories;

public class UserNotificationPreferencesRepository(ScrivenerSyncDbContext db) : IUserNotificationPreferencesRepository
{
    public async Task<UserNotificationPreferences?> GetByUserIdAsync(Guid userId, CancellationToken ct = default) =>
        await db.NotificationPreferences.FirstOrDefaultAsync(p => p.UserId == userId, ct);

    public async Task AddAsync(UserNotificationPreferences preferences, CancellationToken ct = default) =>
        await db.NotificationPreferences.AddAsync(preferences, ct);
}
