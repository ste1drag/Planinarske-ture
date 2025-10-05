using Notifications.Domain.Entities;

namespace Notifications.Domain.Interfaces
{
    public interface IInAppNotificationRepository
    {
        Task<InAppNotification?> GetByIdAsync(string id);
        Task<IEnumerable<InAppNotification>> GetByUserIdAsync(string userId);
        Task<IEnumerable<InAppNotification>> GetAllAsync();
        Task<InAppNotification> CreateAsync(InAppNotification notification);
        Task<InAppNotification?> UpdateAsync(InAppNotification notification);
        Task<bool> DeleteAsync(string id);
    }
}
