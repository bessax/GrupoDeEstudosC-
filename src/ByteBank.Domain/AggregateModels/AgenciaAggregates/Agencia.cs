namespace ByteBank.Domain.AggregateModels.AgenciaAggregates;

public class Agencia : Entity, IAggregateRoot
{
    public Agencia(string nome, Endereco endereco)
    {
        Nome = nome;
        Endereco = endereco;
    }

#pragma warning disable CS8618
    private Agencia() { }
#pragma warning restore CS8618

    public string Nome { get; private set; }
    public Endereco Endereco { get; private set; }
    public string Numero => $"{Id:D6}";

    public void UpdateNome(string nome)
    {
        Nome = nome;
    }
}