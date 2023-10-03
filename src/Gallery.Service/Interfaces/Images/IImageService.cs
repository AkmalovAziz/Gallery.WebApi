using Gallery.Application.Utils;
using Gallery.DataAccess.ViewModels;
using Gallery.Persistance.Dtos.Images;

namespace Gallery.Service.Interfaces.Images;

public interface IImageService
{
    public Task<bool> CreateAsync(ImageCreateDto dto);
    public Task<bool> UpdateAsync(long imageId, ImageUpdateDto dto);
    public Task<bool> DeleteAsync(long imageId);
    public Task<ImageViewModel> GetByIdAsync(long imageId);
    public Task<IList<ImageViewModel>> GetAllAsync(Paginationparams @params);
    public Task<long> CountAsync();
}