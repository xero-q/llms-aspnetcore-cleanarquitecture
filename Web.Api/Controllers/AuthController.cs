using Application.Contracts.Requests;
using Application.Contracts.Responses;
using Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[ApiController]
public class AuthController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost(ApiEndpoints.Auth.Login)]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest request)
    {
        var userPasswordCorrect = await authenticationService.VerifyUser(request);

        if (!userPasswordCorrect)
        {
            return Unauthorized();
        }
        
        var token = await authenticationService.GenerateToken(request.Username);

        if (token == null)
        {
            return BadRequest();
        }

        var response = new LoginResponse
        {
            Access = token,
        };
            
        return Ok(response);
    }
}