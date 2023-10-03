namespace Gallery.Application.Exceptions.Auth;

public class UnAuthorizeException : BadRequestException
{
    public UnAuthorizeException()
    {
        this.TitleMessage = "You are not registered!";
    }
}