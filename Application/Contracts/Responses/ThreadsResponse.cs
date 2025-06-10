namespace Application.Contracts.Responses;
public sealed class ThreadsResponse
{
    public required string Date { get; init; }
    public IEnumerable<ThreadResponse> Threads { get; init; } = [];
}