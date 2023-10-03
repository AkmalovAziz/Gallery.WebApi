namespace Gallery.Application.Exceptions.Images;

public class ImageNotFoundException : NotFoundException
{
    public ImageNotFoundException()
    {
        this.TitleMessage = "Image is not found";
    }
}