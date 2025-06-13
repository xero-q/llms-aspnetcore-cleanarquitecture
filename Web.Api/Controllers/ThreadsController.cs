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
    public async Task<IActionResult> Create([FromRoute] int id,[FromBody] CreateThreadRequest request, CancellationToken cancellationToken)
    {
        var userResult = await GetValidatedUserIdAsync();
        if (userResult is IActionResult errorResult)
        {
            return errorResult;
        }

        var userId = userResult as int? ?? 0;
        
        var threadExists = await threadService.TitleExistsAsync(userId, request.Title, cancellationToken);

        if (threadExists)
        {
            return BadRequest(new {error = ErrorMessages.ThreadSameTitleExists});
        }
        
        var thread = request.MapToThread(id, userId);
        await threadService.CreateAsync(thread, cancellationToken);
        var response = thread.MapToSimpleResponse();

        return Created();
    }
    
    [HttpGet(ApiEndpoints.Threads.GetAll)]
    [Authorize]
    public async Task<IActionResult> GetThreads(CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var userResult = await GetValidatedUserIdAsync();
        if (userResult is IActionResult errorResult)
        {
            return errorResult;
        }

        var userId = userResult as int? ?? 0;
        
        var totalThreads = await threadService.GetTotalThreadsCount(userId, cancellationToken);
        
        bool hasMorePages = page * pageSize < totalThreads;

        var threads = await threadService.GetAllByUserIdGroupedByDateAsync(userId, page, pageSize, cancellationToken);

        var response = threads.MapToResponse(page, hasMorePages);
        
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Threads.Delete)]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] int id,CancellationToken cancellationToken)
    {
        var threadDeleted = await threadService.DeleteByIdAsync(id, cancellationToken);

        if (threadDeleted == false)
        {
            return NotFound(new { error = ErrorMessages.ThreadNotFound });
        }
        
        return Ok();
    }
    
    private async Task<object> GetValidatedUserIdAsync()
    {
        var userId = HttpContext.GetUserId();

        if (userId == null)
        {
            return BadRequest(new { error = ErrorMessages.TokenHasNotUserId });
        }

        var isValidInt = int.TryParse(userId, out var userIdInt);
        if (!isValidInt)
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