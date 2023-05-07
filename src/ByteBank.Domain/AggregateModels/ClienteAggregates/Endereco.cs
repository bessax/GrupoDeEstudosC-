namespace ByteBank.Domain.AggregateModels.ClienteAggregates;

public class Endereco
{
    public Endereco(string logradouro, string cep, int numero, string? complemento = null)
    {
        Logradouro = logradouro;
        Complemento = complemento;
        Cep = cep;
        Numero = numero;
    }

    public string Logradouro { get; private set; }
    public string? Complemento { get; private set; }
    public string Cep { get; private set; }
    public int Numero { get; private set; }

    public void UpdateLogradouro(string logradouro)
    {
        Logradouro = logradouro;
    }

    public void UpdateComplemento(string? complemento)
    {
        Complemento = complemento;
    }

    public void UpdateCep(string cep)
    {
        Cep = cep;
    }

    public void UpdateNumero(int numero)
    {
        Numero = numero;
    }
}


// public string Cpf { get; set; }