using Application.Abstractions.Services;
using Application.Contracts.Requests;
using Application.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

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

    [HttpPost(ApiEndpoints.Prompts.Create)]
    [Authorize]
    public async Task<IActionResult> Create([FromRoute] int id, [FromBody] CreatePromptRequest request)
    {
        var prompt = await promptService.AddPromptAsync(id, request.Prompt);

        if (prompt == null)
        {
            return BadRequest(new {error=ErrorMessages.PromptNotCreated});
        }
        var response = prompt.MapToResponse();
        return Created("",response);
    }
}