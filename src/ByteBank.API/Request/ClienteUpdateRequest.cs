using ByteBank.API.Enums;

namespace ByteBank.API.Request;
public class ClienteUpdateRequest
{
    public string? Nome { get; set; }
    required public TipoCliente Tipo { get; set; }

}