namespace ByteBank.Application.Requests;

public record UpdateAgencia(
    int Id,
    string Nome,
    string Logradouro,
    string Cep,
    int Numero,
    string? Complemento = null)
        : IRequest<Result<UpdateAgenciaResultValue>>;