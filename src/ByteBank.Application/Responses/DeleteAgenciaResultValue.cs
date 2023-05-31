namespace ByteBank.Application.Responses;

public record DeleteAgenciaResultValue(
    int Id,
    string Nome,
    string Logradouro,
    string Cep,
    int Numero,
    string? Complemento);