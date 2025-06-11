namespace Application.Contracts.Requests;

public sealed class CreateThreadRequest
{
    public required string Title { get; init; }

}