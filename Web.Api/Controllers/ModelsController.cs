using Application.Contracts.Requests;
using Application.Mappings;
using Application.Abstractions.Services;
using SharedKernel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[ApiController]
public class ModelsController(IModelService modelService, IModelTypeService modelTypeService)
    : ControllerBase
{
    [HttpPost(ApiEndpoints.Models.Create)]
    [Authorize("Admin")]
    public async Task<IActionResult> Create([FromBody] CreateModelRequest request, CancellationToken cancellationToken)
    {
        // Verify ModelType exists
        var modelType = await modelTypeService.GetByIdAsync(request.ModelTypeId, cancellationToken);

        if (modelType == null)
        {
            return BadRequest(new {error=ErrorMessages.ModelTypeNotFound});
        }
        
        var model = request.MapToModel();
        await modelService.CreateAsync(model, cancellationToken);
        var modelResponse = model.MapToResponse();
        return CreatedAtAction(nameof(Get), new { id = model.Id }, modelResponse);
    }

    [HttpGet(ApiEndpoints.Models.GetAll)]
    [Authorize]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var models = await modelService.GetAllAsync(cancellationToken);
        var response = models.MapToResponse().Items;
        
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.Models.Get)]
    [Authorize]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        var model = await modelService.GetByIdAsync(id, cancellationToken);

        if (model == null)
        {
            return NotFound();
        }
        
        var response = model.MapToResponse();
        
        return Ok(response);
    }
}