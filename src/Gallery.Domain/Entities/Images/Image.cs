namespace Gallery.Domain.Entities.Images;

public class Image : AudiTable
{
    public long UserId { get; set; }
    public string Name { get; set; } = string.Empty;
}