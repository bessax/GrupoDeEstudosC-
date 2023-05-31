namespace ByteBank.Application.Requests;

public record GetAgenciaById(int Id)
    : IRequest<Result<GetAgenciaByIdResultValue>>;