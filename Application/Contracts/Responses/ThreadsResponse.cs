namespace Application.Contracts.Responses;

public sealed class ThreadsResponse
{
    public IEnumerable<ThreadResponse> Items { get; init; } = [];
}