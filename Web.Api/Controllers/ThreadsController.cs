using Application.Abstractions.Services;
using Application.Contracts.Requests;
using Application.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web.Api.Controllers;

[ApiController]
public class ThreadsController(IThreadService threadService, IUserService userService):ControllerBase
{
    
    [HttpPost(ApiEndpoints.Threads.Create)]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateThreadRequest request)
    {
        var threadExists = await threadService.TitleExistsAsync(request.Title);

        if (threadExists)
        {
            return BadRequest(new {error = ErrorMessages.ThreadSameTitleExists});
        }
        
        var userResult = await GetValidatedUserIdAsync();
        if (userResult is IActionResult errorResult)
        {
            return errorResult;
        }

        var userIdInt = userResult as int? ?? 0;
        
        var thread = request.MapToThread(userIdInt);
        await threadService.CreateAsync(thread);
        var response = thread.MapToSimpleResponse();

        return Created();
    }
    
    [HttpGet(ApiEndpoints.Threads.GetAll)]
    [Authorize]
    public async Task<IActionResult> GetThreads([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var userResult = await GetValidatedUserIdAsync();
        if (userResult is IActionResult errorResult)
        {
            return errorResult;
        }

        var userIdInt = userResult as int? ?? 0;
        
        var totalThreads = await threadService.GetTotalThreadsCount(userIdInt);
        
        bool hasMorePages = page * pageSize < totalThreads;

        var threads = await threadService.GetAllByUserIdGroupedByDateAsync(userIdInt, page, pageSize);

        var response = threads.MapToResponse(page, hasMorePages);
        
        return Ok(response);
    }
    
    private async Task<object> GetValidatedUserIdAsync()
    {
        var userId = HttpContext.GetUserId();

        if (userId == null)
        {
            return BadRequest(new { error = ErrorMessages.TokenHasNotUserId });
        }

        var validInt = int.TryParse(userId, out var userIdInt);
        if (!validInt)
        {
            return BadRequest(new { error = ErrorMessages.TokenInvalidUserId });
        }

        var existingUser = await userService.GetByIdAsync(userIdInt);
        if (existingUser == null)
        {
            return BadRequest(new { error = ErrorMessages.TokenInvalidUser });
        }

        return userIdInt;
    }
}