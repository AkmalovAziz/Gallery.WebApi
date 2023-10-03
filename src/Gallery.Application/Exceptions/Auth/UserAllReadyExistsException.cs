namespace Gallery.Application.Exceptions.Auth;

public class UserAllReadyExistsException : AllReadyExistsException
{
    public UserAllReadyExistsException()
    {
        this.TitleMessage = "This email is registered";
    }
}