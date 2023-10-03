using Gallery.Domain.Entities.Users;

namespace Gallery.Service.Interfaces.Auth;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);
}