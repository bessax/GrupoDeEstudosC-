namespace ByteBank.Application.Responses;

public record GetAgenciaByIdResultValue(
    int Id,
    string Nome,
    string Logradouro,
    string Cep,
    int Numero,
    string? Complemento);