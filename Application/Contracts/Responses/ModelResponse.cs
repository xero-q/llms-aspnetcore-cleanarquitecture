namespace Application.Contracts.Responses;

public sealed class ModelResponse
{
    public int Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Identifier { get; init; }

    public required string ModelType { get; init; }
    
    public required double Temperature { get; init; }
    
    public required string EnvironmentVariable { get; init; }

}