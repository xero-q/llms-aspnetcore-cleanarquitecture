using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Abstractions.Services;
using Application.Contracts.Requests;
using Application.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class AuthenticationService(IConfiguration config, IUserService userService) : IAuthenticationService
{
    public async Task<bool> VerifyUser(LoginRequest request)
    {
        var user = await userService.GetByUsernameAsync(request.Username);

        if (user == null)
        {
            return false;
        }

        return PasswordHelper.VerifyPassword(request.Password, user.Password);
    }
    
    public async Task<string?> GenerateToken(string username)
    {
        var user = await userService.GetByUsernameAsync(username);

        if (user == null)
        {
            return null;
        }
        
        var jwtConfig = config.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim("userId",user.Id.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: jwtConfig["Issuer"],
            audience: jwtConfig["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtConfig["DurationInMinutes"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}