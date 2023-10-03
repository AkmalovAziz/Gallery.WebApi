using FluentValidation;
using Gallery.Persistance.Dtos.Images;
using Gallery.Persistance.Helpers;

namespace Gallery.Persistance.Validations.Images;

public class ImagesCreateValidator : AbstractValidator<ImageCreateDto>
{
    public ImagesCreateValidator()
    {
        int MaxImageSizeMB = 5;
        RuleFor(dto => dto.ImagePath).NotEmpty().NotNull().WithMessage("Image field is required");

        RuleFor(dto => dto.ImagePath.Length).LessThan(MaxImageSizeMB * 1024 * 1024)
            .WithMessage($"Image size must be less than {MaxImageSizeMB} MB");
        RuleFor(dto => dto.ImagePath.FileName).Must(predicate =>
        {
            var fileinfo = new FileInfo(predicate);

            return MediaHelpers.GetImageExtension().Contains(fileinfo.Extension);
        }).WithMessage("This file type isn't image file");
    }
}