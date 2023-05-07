namespace ByteBank.Application.Requests;

public record DeleteAgencia(int Id)
    : IRequest<Result<DeleteAgenciaResultValue>>;