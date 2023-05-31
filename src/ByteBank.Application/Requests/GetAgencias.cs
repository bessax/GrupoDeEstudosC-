namespace ByteBank.Application.Requests;

public record GetAgencias()
    : IRequest<Result<GetAgenciasResultValue>>;