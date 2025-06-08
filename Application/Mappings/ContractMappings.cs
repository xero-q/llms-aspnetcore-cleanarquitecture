using Application.Contracts.Requests;
using Application.Contracts.Responses;
using Domain.Entities;

namespace Application.Mappings;

public static class ContractMappings
{
    public static ModelType MapToModelType(this CreateModelTypeRequest request)
    {
        return new ModelType
        {
            Name = request.Name
        };
    }
    
    public static ModelTypeResponse MapToResponse(this ModelType modelType)
    {
        return new ModelTypeResponse
        {
            Id = modelType.Id,
            Name = modelType.Name
        };
    }
    
    public static ModelTypesResponse MapToResponse(this IEnumerable<ModelType> modelTypes)
    {
        return new ModelTypesResponse
        {
            Items = modelTypes.Select(MapToResponse)
        };
    }
    
    public static User MapToUser(this CreateUserRequest request)
    {
        return new User
        {
            Username = request.Username,
            Password = request.Password
        };
    }
    
    public static UserResponse MapToResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Username = user.Username
        };
    }
    
    public static Model MapToModel(this CreateModelRequest request)
    {
        return new Model
        {
            Name = request.Name,
            Identifier = request.Identifier,
            Temperature = request.Temperature,
            ModelTypeId = request.ModelTypeId,
            EnvironmentVariable = request.EnvironmentVariable
        };
    }
    
    public static ModelResponse MapToResponse(this Model model)
    {
        return new ModelResponse
        {
            Id = model.Id,
            Name = model.Name,
            Identifier = model.Identifier,
            Temperature = model.Temperature,
            ModelTypeId = model.ModelTypeId,
            EnvironmentVariable = model.EnvironmentVariable
        };
    }
    
    public static ModelsResponse MapToResponse(this IEnumerable<Model> models)
    {
        return new ModelsResponse
        {
            Items = models.Select(MapToResponse)
        };
    }
    
}