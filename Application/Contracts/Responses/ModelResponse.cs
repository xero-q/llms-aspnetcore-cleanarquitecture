namespace Application.Contracts.Responses;

public class ModelResponse
{
    public int Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Identifier { get; init; }

    public required double Temperature { get; init; }
    
    public required string EnvironmentVariable { get; init; }
    
    public required int ModelTypeId { get; init; }

}