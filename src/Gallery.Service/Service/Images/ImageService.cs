using Gallery.Application.Exceptions.Auth;
using Gallery.Application.Exceptions.Images;
using Gallery.Application.Utils;
using Gallery.DataAccess.Interfaces.Images;
using Gallery.DataAccess.ViewModels;
using Gallery.Persistance.Dtos.Images;
using Gallery.Persistance.Helpers;
using Gallery.Service.Interfaces.Commons;
using Gallery.Service.Interfaces.Images;
using Image = Gallery.Domain.Entities.Images.Image;

namespace Gallery.Service.Service.Images;

public class ImageService : IImageService
{
    private IImageRepository _repository;
    private IPaginator _paginator;
    private IIdentityService _identity;
    private IFileService _fileservice;

    public ImageService(IImageRepository repository, IIdentityService identity,
        IPaginator paginator, IFileService fileService)
    {
        this._repository = repository;
        this._paginator = paginator;
        this._identity = identity;
        this._fileservice = fileService;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(ImageCreateDto dto)
    {
        if (_identity.Email is null) throw new UnAuthorizeException();
        var image = new Image();

        var imageName = await _fileservice.UploadImageAsync(dto.ImagePath);
        if (imageName is null) throw new ImageNotFoundException();

        image.Name = imageName;
        image.UserId = _identity.UserId;
        image.CreatedAt = image.UpdatedAt = TimeHelpers.GetDateTime();
        var result = await _repository.CreateAsync(image);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long imageId)
    {
        var image = await _repository.GetByIdAsync(imageId);
        if (image is null) throw new ImageNotFoundException();

        if (_identity.IdentityRole != "Admin" && _identity.UserId != image.UserId)
            throw new UnAuthorizeException();

        var result = await _repository.DeleteAsync(imageId);
        var delete = await _fileservice.DeleteImageAsync(image.Name);

        return result > 0;
    }

    public async Task<IList<ImageViewModel>> GetAllAsync(Paginationparams @params)
    {
        var image = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return image;
    }

    public async Task<ImageViewModel> GetByIdAsync(long imageId)
    {
        var image = await _repository.GetByIdAsync(imageId);
        if (image is null) throw new ImageNotFoundException();

        return image;
    }

    public async Task<bool> UpdateAsync(long imageId, ImageUpdateDto dto)
    {
        var image = await _repository.GetByIdAsync(imageId);
        if (image is null) throw new ImageNotFoundException();

        if (_identity.IdentityRole != "Admin" && _identity.UserId != image.UserId)
            throw new UnAuthorizeException();

        var deleteImage = await _fileservice.DeleteImageAsync(image.Name);
        if (deleteImage == false) throw new ImageNotFoundException();

        var newImageName = await _fileservice.UploadImageAsync(dto.ImagePath);
        if (newImageName is null) throw new ImageNotFoundException();

        var newImage = await _repository.GetIdAsync(imageId);
        newImage.Name = newImageName;
        newImage.UpdatedAt = TimeHelpers.GetDateTime();
        var result = await _repository.UpdateAsync(imageId, newImage);

        return result > 0;
    }
}