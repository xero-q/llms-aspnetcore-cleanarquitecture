using Application.Contracts.Requests;
using Application.Mappings;
using Application.Abstractions.Services;
using SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost(ApiEndpoints.Auth.Signup)]
    public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        if (await userService.UsernameExistsAsync(request.Username, cancellationToken))
        {
            return BadRequest(new { error = ErrorMessages.UsernameAlreadyExists });
        }
        
        var user = request.MapToUser();
        await userService.CreateAsync(user,cancellationToken);
        var userResponse = user.MapToResponse();
        // TODO: return CreatedAtAction(nameof(Get), new { id = user.Id }, userResponse);
        return Created();
    }
}