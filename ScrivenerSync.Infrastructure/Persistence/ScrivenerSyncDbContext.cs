using Microsoft.EntityFrameworkCore;
using ScrivenerSync.Domain.Entities;
using ScrivenerSync.Domain.Interfaces.Repositories;

namespace ScrivenerSync.Infrastructure.Persistence;

public class ScrivenerSyncDbContext : DbContext, IUnitOfWork
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Invitation> Invitations { get; set; } = default!;
    public DbSet<ScrivenerProject> Projects { get; set; } = default!;
    public DbSet<Section> Sections { get; set; } = default!;
    public DbSet<Comment> Comments { get; set; } = default!;
    public DbSet<ReadEvent> ReadEvents { get; set; } = default!;
    public DbSet<UserNotificationPreferences> NotificationPreferences { get; set; } = default!;
    public DbSet<EmailDeliveryLog> EmailDeliveryLogs { get; set; } = default!;

    public ScrivenerSyncDbContext(DbContextOptions<ScrivenerSyncDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScrivenerSyncDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
