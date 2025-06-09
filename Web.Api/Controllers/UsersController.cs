using Application.Contracts.Requests;
using Application.Mappings;
using Application.Services;
using Domain.Entities;
using SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost(ApiEndpoints.Users.Create)]
    public async Task<ActionResult<User>> RegisterUser([FromBody] CreateUserRequest request)
    {
        if (await userService.UsernameExistsAsync(request.Username))
        {
            return BadRequest(new { error = ErrorMessages.UsernameAlreadyExists });
        }
        
        var user = request.MapToUser();
        await userService.CreateAsync(user);
        var userResponse = user.MapToResponse();
        // TODO: return CreatedAtAction(nameof(Get), new { id = user.Id }, userResponse);
        return Created();
    }
}