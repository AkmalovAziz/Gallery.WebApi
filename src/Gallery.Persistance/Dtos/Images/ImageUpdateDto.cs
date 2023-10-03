using Microsoft.AspNetCore.Http;

namespace Gallery.Persistance.Dtos.Images;

public class ImageUpdateDto
{
    public IFormFile? ImagePath { get; set; }
}