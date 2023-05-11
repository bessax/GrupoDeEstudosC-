namespace ByteBank.Application.Responses;

public record UpdateAgenciaResultValue(
    int Id,
    string Nome,
    string Logradouro,
    string Cep,
    int Numero,
    string? Complemento);