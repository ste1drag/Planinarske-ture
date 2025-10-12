using Notifications.Domain.Entities;

namespace Notifications.Application.Contracts;

public interface IInAppNotificationRepository : IAsyncRepository<InAppNotification>
{
    Task<IReadOnlyList<InAppNotification>> GetByMountainIdAsync(string mountainId);
}