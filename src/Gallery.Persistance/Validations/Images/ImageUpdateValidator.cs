using FluentValidation;
using Gallery.Persistance.Dtos.Images;
using Gallery.Persistance.Helpers;

namespace Gallery.Persistance.Validations.Images;

public class ImageUpdateValidator : AbstractValidator<ImageUpdateDto>   
{
    public ImageUpdateValidator()
    {
        When(dto => dto.ImagePath is not null, () =>
        {
            int maxImageSizeMB = 5;
            RuleFor(dto => dto.ImagePath!.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.ImagePath!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);

                return MediaHelpers.GetImageExtension().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}