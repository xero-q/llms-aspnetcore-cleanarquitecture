using Application.Contracts.Requests;
using Application.Mappings;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Web.Api.Controllers;

[ApiController]
public class ModelTypesController(IModelTypeService modelTypeService) : ControllerBase
{
    [HttpPost(ApiEndpoints.ModelTypes.Create)]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateModelTypeRequest request)
    {
        var modelType = request.MapToModelType();
        await modelTypeService.CreateAsync(modelType);
        var modelTypeResponse = modelType.MapToResponse();
        return CreatedAtAction(nameof(Get), new { id = modelType.Id }, modelTypeResponse);
    }

    [HttpGet(ApiEndpoints.ModelTypes.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var modelTypes = await modelTypeService.GetAllAsync();
        var response = modelTypes.MapToResponse();
        
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.ModelTypes.Get)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var modelType = await modelTypeService.GetByIdAsync(id);

        if (modelType == null)
        {
            return NotFound();
        }
        
        var response = modelType.MapToResponse();
        
        return Ok(response);
    }
}

