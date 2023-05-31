namespace ByteBank.Application.Responses;

public record GetAgenciasResultValueItem(
    int Id,
    string Nome,
    string Logradouro,
    string Cep,
    int Numero,
    string? Complemento);