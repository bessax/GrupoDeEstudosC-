namespace ByteBank.Application.Responses;

public record CreateAgenciaResultValue(
    int Id,
    string Nome,
    string Logradouro,
    string Cep,
    int Numero,
    string? Complemento);