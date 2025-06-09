using Application.Contracts.Requests;
using Application.Contracts.Responses;
using Application.Services;
using SharedKernel;
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
        
        var token = authenticationService.GenerateToken(request.Username);

        var response = new LoginResponse
        {
            Token = token,
        };
            
        return Ok(response);
    }
}