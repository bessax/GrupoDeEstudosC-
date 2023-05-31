namespace ByteBank.Domain.AggregateModels.ClienteAggregates;

public abstract class Cliente : Entity, IAggregateRoot
{
    protected Cliente(string nome, Endereco endereco)
    {
        Nome = nome;
        Endereco = endereco;
    }

#pragma warning disable CS8618
    protected Cliente() { }
#pragma warning restore CS8618

    public string Nome { get; set; }
    public Endereco Endereco { get; set; }

    public void UpdateNome(string nome)
    {
        Nome = nome;
    }
}