using Application.Contracts.Requests;
using Application.Contracts.Responses;
using Domain.Entities;
using Thread = Domain.Entities.Thread;

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
            ModelType = model.Provider.Name
        };
    }
    
    public static ModelsResponse MapToResponse(this IEnumerable<Model> models)
    {
        return new ModelsResponse
        {
            Items = models.Select(MapToResponse)
        };
    }

    public static Thread MapToThread(this CreateThreadRequest request,int modelId, int userId)
    {
        return new Thread
        {
            Title = request.Title,
            ModelId = modelId,
            UserId = userId
        };
    }

    private static ThreadResponse MapToResponse(this Thread thread)
    {
        return new ThreadResponse
        {
            Id = thread.Id,
            Title = thread.Title,
            ModelId = thread.ModelId,
            CreatedAt = thread.CreatedAt,
            CreatedAtDate = thread.CreatedAt.ToString("yyyy-MM-dd"),
            ModelName = thread.Model.Name,
            ModelType = thread.Model.Provider.Name,
            ModelIdentifier = thread.Model.Identifier
        };
    }
    
    public static ThreadSimpleResponse MapToSimpleResponse(this Thread thread)
    {
        return new ThreadSimpleResponse
        {
            Id = thread.Id,
            Title = thread.Title,
            ModelId = thread.ModelId,
            CreatedAt = thread.CreatedAt
        };
    }
    
    
    public static PaginatedThreadsResponse MapToResponse(this Dictionary<string, List<Thread>> threads, int currentPage, bool hasNext)
    {
       return new PaginatedThreadsResponse
        {
            CurrentPage = currentPage,
            HasNext = hasNext,
            Results = threads.Select(x=>new ThreadsResponse
            {
                Date = x.Key,
                Threads = x.Value.Select(MapToResponse)
            })
        };
    }

    public static PromptResponse MapToResponse(this Prompt prompt)
    {
        return new PromptResponse
        {
            Id = prompt.Id,
            Prompt = prompt.PromptText,
            Response = prompt.Response,
            ThreadId = prompt.ThreadId,
            CreateAt = prompt.CreatedAt
        };
    }
    
    public static PromptsResponse MapToResponse(this IEnumerable<Prompt> prompts)
    {
        return new PromptsResponse
        {
            Items = prompts.Select(MapToResponse)
        };
    }
    
}