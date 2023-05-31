namespace ByteBank.Application.Requests;

public record CreateAgencia(
    string Nome,
    string Logradouro,
    string Cep,
    int Numero,
    string? Complemento = null)
        : IRequest<Result<CreateAgenciaResultValue>>;