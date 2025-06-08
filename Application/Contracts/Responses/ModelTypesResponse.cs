namespace Application.Contracts.Responses;

public sealed class ModelTypesResponse
{
    public IEnumerable<ModelTypeResponse> Items { get; init; } = [];
}