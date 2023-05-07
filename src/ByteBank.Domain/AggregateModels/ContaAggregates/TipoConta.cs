namespace ByteBank.Domain.AggregateModels.ContaAggregates;

public class TipoConta : Enumeration
{
    public static readonly TipoConta Corrente = new(1, nameof(Corrente));
    public static readonly TipoConta Poupanca = new(2, nameof(Poupanca));

    private TipoConta(int id, string name)
        : base(id, name)
    {
    }
}