namespace Darwin.Contracts.V1.Responses;

public record Response
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ResponseSentUTC { get; set; } = DateTime.UtcNow.ToString("o");
};

public record Response<T> : Response
{
    public T Data { get; init; }

    public Response(T data)
    {
        Data = data;
    }
}