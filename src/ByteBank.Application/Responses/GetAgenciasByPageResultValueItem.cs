namespace ByteBank.Application.Responses;

public record GetAgenciasByPageResultValueItem(
    int Id,
    string Nome,
    string Logradouro,
    string Cep,
    int Numero,
    string? Complemento);