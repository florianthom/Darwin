namespace hello_asp_identity.Contracts.V1.Responses;

public record ErrorResponse<T>(
    List<T> Errors
) : BaseResponse;