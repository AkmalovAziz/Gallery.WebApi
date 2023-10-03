namespace Gallery.Application.Exceptions.Auth;

public class PasswordIncorrectedException : BadRequestException
{
    public PasswordIncorrectedException()
    {
        this.TitleMessage = "Password is invalid";
    }
}