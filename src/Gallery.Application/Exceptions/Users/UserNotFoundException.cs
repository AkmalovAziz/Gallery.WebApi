namespace Gallery.Application.Exceptions.Users;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException()
    {
        this.TitleMessage = "User is not found";
    }
}