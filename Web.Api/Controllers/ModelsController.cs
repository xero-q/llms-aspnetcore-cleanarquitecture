using Application.Contracts.Requests;
using Application.Mappings;
using Application.Services;
using SharedKernel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[ApiController]
public class ModelsController(IModelService modelService, IModelTypeService modelTypeService)
    : ControllerBase
{
    [HttpPost(ApiEndpoints.Models.Create)]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateModelRequest request)
    {
        // Verify ModelType exists
        var modelType = await modelTypeService.GetByIdAsync(request.ModelTypeId);

        if (modelType == null)
        {
            return BadRequest(new {error=ErrorMessages.ModelTypeNotFound});
        }
        
        var model = request.MapToModel();
        await modelService.CreateAsync(model);
        var modelResponse = model.MapToResponse();
        return Created();
        //TODO return CreatedAtAction(nameof(GetModelType), new { id = modelType.Id }, modelTypeResponse);
    }

    [HttpGet(ApiEndpoints.Models.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var models = await modelService.GetAllAsync();
        var response = models.MapToResponse();
        
        return Ok(response);
    }
}