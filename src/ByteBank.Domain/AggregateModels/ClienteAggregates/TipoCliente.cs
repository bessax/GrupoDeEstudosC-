namespace ByteBank.Domain.AggregateModels.ClienteAggregates;

public class TipoCliente : Enumeration
{
    public static readonly TipoCliente Fisico = new(1, nameof(Fisico));
    public static readonly TipoCliente Juridico = new(2, nameof(Juridico));

    private TipoCliente(int id, string name) : base(id, name)
    {
    }
}