using Application.Contracts.Requests;
using Application.Mappings;
using Domain.Entities;
using Domain.Interfaces;
using LLMStudio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[ApiController]
public class UsersController(IUserRepository userRepository) : ControllerBase
{
    [HttpPost(ApiEndpoints.Users.Create)]
    public async Task<ActionResult<User>> RegisterUser([FromBody] CreateUserRequest request)
    {
        if (await userRepository.UsernameExistsAsync(request.Username))
        {
            return BadRequest(new { error = ErrorMessages.UsernameAlreadyExists });
        }
        
        var user = request.MapToUser();
        await userRepository.CreateAsync(user);
        var userResponse = user.MapToResponse();
        // TODO: return CreatedAtAction(nameof(Get), new { id = user.Id }, userResponse);
        return Created();
    }
}