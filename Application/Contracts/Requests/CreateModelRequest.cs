namespace Application.Contracts.Requests;

public class CreateModelRequest
{
    public required string Name { get; init; }
    
    public required string Identifier { get; init; }

    public required double Temperature { get; init; } = 0.7;
    public required string EnvironmentVariable { get; init; }
    
    public required int ModelTypeId { get; init; }

}