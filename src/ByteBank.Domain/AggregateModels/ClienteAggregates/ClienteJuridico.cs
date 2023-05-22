namespace ByteBank.Domain.AggregateModels.ClienteAggregates;

// TODO: Analizar se uso ClienteJuridico ou ClientePJ 🤔
public class ClienteJuridico : Cliente
{
    public ClienteJuridico(string nome, Endereco endereco, string cnpj)
        : base(nome, endereco)
    {
        Cnpj = cnpj;
    }

#pragma warning disable CS8618
    private ClienteJuridico()
        : base()
    {
    }
#pragma warning restore CS8618

    public string Cnpj { get; private set; }
}