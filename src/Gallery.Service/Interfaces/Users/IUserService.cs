using Gallery.Application.Utils;
using Gallery.DataAccess.ViewModels;
using Gallery.Persistance.Dtos.Users;

namespace Gallery.Service.Interfaces.Users;

public interface IUserService
{
    public Task<bool> UpdateAsync(long userId, UserUpdateDto dto);
    public Task<bool> DeleteAsync(long userId);
    public Task<IList<UserViewModel>> GetAllAsync(Paginationparams @params);
    public Task<UserViewModel> GetByIdAsync(long userId);
    public Task<IList<UserViewModel>> SearchAsync(string search, Paginationparams @params);
    public Task<long> CountAsync();
}