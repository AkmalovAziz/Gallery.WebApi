using Gallery.Domain.Entities.Users;
using Gallery.Persistance.Helpers;
using Gallery.Service.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gallery.Service.Service.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration.GetSection("Jwt");
    }
    public async Task<string> GenerateToken(User user)
    {
        var identityClaims = new Claim[]
        {
            new Claim("Id", user.UserId.ToString()),
            new Claim("FirstName", user.FirstName),
            new Claim("Lastname", user.LastName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]!));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        int expiresHours = int.Parse(_configuration["Lifetime"]!);
        var token = new JwtSecurityToken
        (
            issuer: _configuration["Issuer"],
            audience: _configuration["Audience"],
            claims: identityClaims,
            expires: TimeHelpers.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}