namespace ByteBank.Application.Responses;

public record GetAgenciasResultValue(
    IEnumerable<GetAgenciasResultValueItem> Items);