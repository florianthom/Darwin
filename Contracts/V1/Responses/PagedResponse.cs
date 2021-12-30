namespace hello_asp_identity.Contracts.V1.Responses;

public record PagedResponse<T> : BaseResponse
{
    public IEnumerable<T> Data { get; init; }

    public int? PageNumber { get; init; }

    public int? PageSize { get; init; }

    public string NextPage { get; init; }

    public string PreviousPage { get; init; }

    public int PagesTotal { get; init; }

    public int ItemsTotal { get; init; }

    public PagedResponse() { }

    public PagedResponse(IEnumerable<T> data)
    {
        Data = data;
    }
}