using ScrivenerSync.Domain.Entities;

namespace ScrivenerSync.Domain.Interfaces.Services;

public interface IPublicationService
{
    Task PublishAsync(Guid sectionId, Guid authorId, CancellationToken ct = default);
    Task UnpublishAsync(Guid sectionId, Guid authorId, CancellationToken ct = default);
    Task<IReadOnlyList<Section>> GetPublishedSectionsAsync(Guid projectId, CancellationToken ct = default);
    Task<IReadOnlyList<Section>> GetPublishableSectionsAsync(Guid projectId, CancellationToken ct = default);
}
