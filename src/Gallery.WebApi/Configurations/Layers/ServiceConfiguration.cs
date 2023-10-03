using Gallery.Service.Interfaces.Auth;
using Gallery.Service.Interfaces.Commons;
using Gallery.Service.Interfaces.Images;
using Gallery.Service.Interfaces.Notifications;
using Gallery.Service.Interfaces.Users;
using Gallery.Service.Service.Auth;
using Gallery.Service.Service.Commons;
using Gallery.Service.Service.Images;
using Gallery.Service.Service.Notification;
using Gallery.Service.Service.Users;

namespace Gallery.WebApi.Configurations.Layers;

public static class ServiceConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //Di contener
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddScoped<IIdentityService, IdentityService>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<ISmsSender, SmsSender>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IImageService, ImageService>();
    }
}