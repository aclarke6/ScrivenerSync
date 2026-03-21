using ScrivenerSync.Domain.Entities;
using ScrivenerSync.Domain.Enumerations;

namespace ScrivenerSync.Domain.Interfaces.Services;

public interface IUserService
{
    Task<Invitation> IssueInvitationAsync(string email, ExpiryPolicy expiryPolicy, DateTime? expiresAt, Guid authorId, CancellationToken ct = default);
    Task<User> AcceptInvitationAsync(string token, string displayName, string passwordHash, CancellationToken ct = default);
    Task CancelInvitationAsync(Guid invitationId, Guid authorId, CancellationToken ct = default);
    Task DeactivateUserAsync(Guid targetUserId, Guid authorId, CancellationToken ct = default);
    Task ReactivateUserAsync(Guid targetUserId, Guid authorId, CancellationToken ct = default);
    Task SoftDeleteUserAsync(Guid targetUserId, Guid authorId, CancellationToken ct = default);
}
