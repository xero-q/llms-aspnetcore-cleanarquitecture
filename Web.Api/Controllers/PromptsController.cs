using Application.Abstractions.Services;
using Application.Contracts.Requests;
using Application.Mappings;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web.Api.Controllers;

[ApiController]
public class PromptsController(IPromptService promptService): ControllerBase
{
    [HttpGet(ApiEndpoints.Prompts.GetAll)]
    [Authorize]
    public async Task<IActionResult> GetAll([FromRoute] int id, CancellationToken cancellationToken)
    {
        var prompts = await promptService.GetAllAsyncByThread(id, cancellationToken);
        var promptsResponse = prompts.MapToResponse();
        return Ok(promptsResponse.Items);
    }

    [HttpPost(ApiEndpoints.Prompts.Create)]
    [Authorize]
    public async Task<IActionResult> Create([FromRoute] int id, [FromBody] CreatePromptRequest request, CancellationToken cancellationToken)
    {
        Prompt? prompt;
        
        try
        {
            prompt = await promptService.AddPromptAsync(id, request.Prompt, cancellationToken);

            if (prompt == null)
            {
                return BadRequest(new { error = ErrorMessages.PromptNotCreated });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {error = ex.Message});
        }
 
        
        var response = prompt.MapToResponse();
        return Created("",response);
    }
}