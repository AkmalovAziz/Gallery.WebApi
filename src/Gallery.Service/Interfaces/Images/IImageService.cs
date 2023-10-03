using Gallery.Application.Utils;
using Gallery.DataAccess.ViewModels;
using Gallery.Persistance.Dtos.Images;

namespace Gallery.Service.Interfaces.Images;

public interface IImageService
{
    public Task<bool> CreateAsync(ImageCreateDto dto);
    public Task<bool> UpdateAsync(long courseId, ImageUpdateDto dto);
    public Task<bool> DeleteAsync(long courseId);
    public Task<ImageViewModel> GetByIdAsync(long courseId);
    public Task<IList<ImageViewModel>> GetAllAsync(Paginationparams @params);
    public Task<long> CountAsync();
}