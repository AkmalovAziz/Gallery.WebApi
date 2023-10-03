using Gallery.Domain.Constans;

namespace Gallery.Persistance.Helpers;

public class TimeHelpers
{
    public static DateTime GetDateTime()
    {
        var datetime = DateTime.UtcNow;
        datetime.AddHours(TimeConstans.UTC);

        return datetime;
    }
}