namespace Gallery.Application.Exceptions.Auth;

public class VerificationTooManyRequestException : TooManyRequestException
{
    public VerificationTooManyRequestException()
    {
        this.TitleMessage = "You tried more than limits!";
    }
}