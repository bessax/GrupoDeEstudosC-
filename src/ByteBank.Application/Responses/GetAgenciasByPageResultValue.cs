namespace ByteBank.Application.Responses;

public record GetAgenciasByPageResultValue(
    IEnumerable<GetAgenciasByPageResultValueItem> Items);