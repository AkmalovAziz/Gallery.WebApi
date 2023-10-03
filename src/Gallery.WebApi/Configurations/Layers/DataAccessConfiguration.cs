using Gallery.DataAccess.Interfaces.Images;
using Gallery.DataAccess.Interfaces.Users;
using Gallery.DataAccess.Repositories.Images;
using Gallery.DataAccess.Repositories.Users;

namespace Gallery.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //DI Contener
        builder.Services.AddScoped<IImageRepository, ImageRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}