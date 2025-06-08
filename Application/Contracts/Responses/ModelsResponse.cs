namespace Application.Contracts.Responses;

public sealed class ModelsResponse
{
    public IEnumerable<ModelResponse> Items { get; init; } = [];
}