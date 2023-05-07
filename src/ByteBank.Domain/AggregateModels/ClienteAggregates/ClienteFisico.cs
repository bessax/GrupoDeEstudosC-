namespace ByteBank.Domain.AggregateModels.ClienteAggregates;

// TODO: Analizar se uso ClienteFisico ou ClientePF 🤔
public class ClienteFisico : Cliente
{
    public ClienteFisico(string nome, Endereco endereco, string cpf)
        : base(nome, endereco)
    {
        Cpf = cpf;
    }

    #pragma warning disable CS8618
    private ClienteFisico()
        : base()
    {
    }
    #pragma warning restore CS8618

    public string Cpf { get; private set; }
}