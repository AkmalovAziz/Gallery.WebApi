using Gallery.Persistance.Dtos.Auth;

namespace Gallery.Service.Interfaces.Auth;

public interface IAuthService
{
    public Task<(bool Result, int CachedMinutes)> RegisterAsync(RegistrDto dto);
    public Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string email);
    public Task<(bool Result, string Token)> VerifyRegisterAsync(string email, int code);
    public Task<(bool Result, string Token)> LoginAsync(LoginDto loginDto);
}