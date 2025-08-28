using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Notifications.Domain.Entities;
using Notifications.Domain.Interfaces;
using Notifications.Infrastructure.Configuration;

namespace Notifications.Infrastructure.Repositories;

public class MongoInAppNotificationRepository : IInAppNotificationRepository
{
    private readonly IMongoCollection<InAppNotification> _notifications;

    public MongoInAppNotificationRepository(IOptions<MongoDbConfiguration> mongoConfig)
    {
        var client = new MongoClient(mongoConfig.Value.ConnectionString);
        var database = client.GetDatabase(mongoConfig.Value.DatabaseName);
        _notifications = database.GetCollection<InAppNotification>("notifications");
    }

    public async Task<InAppNotification?> GetByIdAsync(string id)
    {
        var filter = Builders<InAppNotification>.Filter.Eq(n => n.Id, id);
        return await _notifications.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<InAppNotification>> GetByUserIdAsync(string userId)
    {
        var filter = Builders<InAppNotification>.Filter.Eq(n => n.UserId, userId);
        return await _notifications.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<InAppNotification>> GetAllAsync()
    {
        return await _notifications.Find(_ => true).ToListAsync();
    }

    public async Task<InAppNotification> CreateAsync(InAppNotification notification)
    {
        await _notifications.InsertOneAsync(notification);
        return notification;
    }

    public async Task<InAppNotification?> UpdateAsync(InAppNotification notification)
    {
        var filter = Builders<InAppNotification>.Filter.Eq(n => n.Id, notification.Id);
        var result = await _notifications.ReplaceOneAsync(filter, notification);

        return result.ModifiedCount > 0 ? notification : null;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var filter = Builders<InAppNotification>.Filter.Eq(n => n.Id, id);
        var result = await _notifications.DeleteOneAsync(filter);

        return result.DeletedCount > 0;
    }
}
