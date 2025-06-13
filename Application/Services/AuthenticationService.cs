using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Abstractions.Services;
using Application.Contracts.Requests;
using Application.Helpers;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class AuthenticationService(IConfiguration config, IUserService userService) : IAuthenticationService
{
    public async Task<User?> AuthenticateUser(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var user = await userService.GetByUsernameAsync(request.Username,cancellationToken);

        if (user == null)
        {
            return null;
        }

        bool passwordMatch =  PasswordHelper.VerifyPassword(request.Password, user.Password);

        if (passwordMatch)
        {
            return user;
        }
        
        return null;
    }
    
    public async Task<string?> GenerateToken(string username, bool isAdmin, CancellationToken cancellationToken = default)
    {
        var user = await userService.GetByUsernameAsync(username, cancellationToken);

        if (user == null)
        {
            return null;
        }
        
        var jwtConfig = config.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, username),
            new Claim("userId",user.Id.ToString())
        };

        if (user.IsAdmin)
        {
            claims.Add(new Claim("Admin", "true"));
        }

        var token = new JwtSecurityToken(
            issuer: jwtConfig["Issuer"],
            audience: jwtConfig["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtConfig["DurationInMinutes"])),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}