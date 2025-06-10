namespace Application.Contracts.Responses;

public sealed class PaginatedThreadsResponse
{
    public required int CurrentPage { get; init; }
    public required bool HasNext { get; init; }
    public required IEnumerable<ThreadsResponse> Results { get; init; } = [];
}