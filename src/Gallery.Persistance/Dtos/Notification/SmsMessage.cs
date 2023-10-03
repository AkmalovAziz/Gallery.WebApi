namespace Gallery.Persistance.Dtos.Notification;

public class SmsMessage
{
    public string Resipient { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}