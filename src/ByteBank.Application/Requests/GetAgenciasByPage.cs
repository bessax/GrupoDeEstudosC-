namespace ByteBank.Application.Requests;

public record GetAgenciasByPage(
    int PageNumber,
    int PageSize)
        : IRequest<Result<GetAgenciasByPageResultValue>>;