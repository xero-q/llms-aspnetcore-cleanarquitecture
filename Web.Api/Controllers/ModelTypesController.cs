using Application.Contracts.Requests;
using Application.Mappings;
using Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Web.Api.Controllers;

[ApiController]
public class ModelTypesController(IModelTypeService modelTypeService) : ControllerBase
{
    [HttpPost(ApiEndpoints.ModelTypes.Create)]
    [Authorize("Admin")]
    public async Task<IActionResult> Create([FromBody] CreateModelTypeRequest request, CancellationToken cancellationToken)
    {
        var modelType = request.MapToModelType();
        await modelTypeService.CreateAsync(modelType, cancellationToken);
        var modelTypeResponse = modelType.MapToResponse();
        return CreatedAtAction(nameof(Get), new { id = modelType.Id }, modelTypeResponse);
    }

    [HttpGet(ApiEndpoints.ModelTypes.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var modelTypes = await modelTypeService.GetAllAsync(cancellationToken);
        var response = modelTypes.MapToResponse();
        
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.ModelTypes.Get)]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        var modelType = await modelTypeService.GetByIdAsync(id, cancellationToken);

        if (modelType == null)
        {
            return NotFound();
        }
        
        var response = modelType.MapToResponse();
        
        return Ok(response);
    }
}

