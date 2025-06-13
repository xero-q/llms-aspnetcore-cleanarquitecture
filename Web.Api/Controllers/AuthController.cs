using Application.Contracts.Requests;
using Application.Contracts.Responses;
using Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web.Api.Controllers;

[ApiController]
public class AuthController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost(ApiEndpoints.Auth.Login)]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await authenticationService.AuthenticateUser(request, cancellationToken);

        if (user == null)
        {
            return Unauthorized(new {error = ErrorMessages.UsernamePasswordInvalid});
        }
        
        var token = await authenticationService.GenerateToken(user.Username,user.IsAdmin, cancellationToken);

        if (token == null)
        {
            return BadRequest(new {error=ErrorMessages.TokenNotGenerated});
        }

        var response = new LoginResponse
        {
            Access = token,
            IsAdmin = user.IsAdmin
        };
            
        return Ok(response);
    }
}