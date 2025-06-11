using Application.Abstractions.Services;
using Application.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[ApiController]
public class PromptsController(IPromptService promptService): ControllerBase
{
    [HttpGet(ApiEndpoints.Prompts.GetAll)]
    [Authorize]
    public async Task<IActionResult> GetAll([FromRoute] int id)
    {
        var prompts = await promptService.GetAllAsyncByThread(id);
        var promptsResponse = prompts.MapToResponse();
        return Ok(promptsResponse.Items);
    }
}