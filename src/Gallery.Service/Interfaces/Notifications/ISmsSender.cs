using Gallery.Persistance.Dtos.Notification;

namespace Gallery.Service.Interfaces.Notifications;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smSMessage);
}