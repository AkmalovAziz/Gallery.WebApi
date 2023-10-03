using Gallery.Application.Exceptions.Auth;
using Gallery.Application.Exceptions.Users;
using Gallery.Application.Utils;
using Gallery.DataAccess.Interfaces.Images;
using Gallery.DataAccess.Interfaces.Users;
using Gallery.DataAccess.ViewModels;
using Gallery.Persistance.Dtos.Users;
using Gallery.Persistance.Helpers;
using Gallery.Service.Interfaces.Commons;
using Gallery.Service.Interfaces.Users;

namespace Gallery.Service.Service.Users
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private IPaginator _paginator;
        private IIdentityService _identity;
        private IImageRepository _image;

        public UserService(IUserRepository repository, IPaginator paginator,
            IIdentityService identity, IImageRepository imageRepository)
        {
            this._repository = repository;
            this._paginator = paginator;
            this._identity = identity;
            this._image = imageRepository;
        }
        public async Task<long> CountAsync() => await _repository.CountAsync();

        public async Task<bool> DeleteAsync(long userId)
        {
            var user = await _repository.GetIdAsync(userId);
            if (user is null) throw new UserNotFoundException();

            var imageDelete = await _image.DeleteAsync(userId);
            var result = await _repository.DeleteAsync(userId);

            return result > 0;
        }

        public async Task<IList<UserViewModel>> GetAllAsync(Paginationparams @params)
        {
            var user = await _repository.GetAllAsync(@params);
            var count = await _repository.CountAsync();
            _paginator.Paginate(count, @params);

            return user;
        }

        public async Task<UserViewModel> GetByIdAsync(long userId)
        {
            var user = await _repository.GetByIdAsync(userId);
            if (user is null) throw new UserNotFoundException();

            return user;
        }

        public async Task<IList<UserViewModel>> SearchAsync(string search, Paginationparams @params)
        {
            var user = await _repository.SearchAsync(search, @params);
            var count = await _repository.CountAsync();
            _paginator.Paginate(count, @params);

            return user;
        }

        public async Task<bool> UpdateAsync(long userId, UserUpdateDto dto)
        {
            var user = await _repository.GetIdAsync(userId);
            if (user is null) throw new UserNotFoundException();

            if (_identity.UserId != userId && _identity.IdentityRole != "Admin")
                throw new UnAuthorizeException();

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Description = dto.Description;
            user.UpdatedAt = TimeHelpers.GetDateTime();
            var result = await _repository.UpdateAsync(userId, user);

            return result > 0;
        }
    }
}