namespace Gallery.Application.Exceptions.Auth;

public class EmailExpiredException : ExpiredException
{
    public EmailExpiredException()
    {
        this.TitleMessage = "This email is expired";
    }
}