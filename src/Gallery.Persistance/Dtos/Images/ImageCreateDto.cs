using Microsoft.AspNetCore.Http;

namespace Gallery.Persistance.Dtos.Images;

public class ImageCreateDto
{
    public IFormFile ImagePath { get; set; } = default!;
}