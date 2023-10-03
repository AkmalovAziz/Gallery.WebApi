using Gallery.DataAccess.Commons.Interfaces;
using Gallery.DataAccess.ViewModels;
using Gallery.Domain.Entities.Users;

namespace Gallery.DataAccess.Interfaces.Users
{
    public interface IUserRepository : IRepository<User, UserViewModel>, ISearch<UserViewModel>
    {
        public Task<User?> GetIdAsync(long id); 
        public Task<User?> GetByEmailAsync(string email);
    }
}