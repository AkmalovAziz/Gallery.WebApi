namespace Gallery.Application.Exceptions.Admin;

public class AdminNotFoundException : NotFoundException
{
    public AdminNotFoundException()
    {
        this.TitleMessage = "Admin is not found";
    }
}