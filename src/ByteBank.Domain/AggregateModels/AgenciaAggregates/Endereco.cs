namespace ByteBank.Domain.AggregateModels.AgenciaAggregates;

public class Endereco
{
    public Endereco(
        string logradouro,
        string cep,
        int numero,
        string? complemento = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(
            logradouro,
            nameof(logradouro));

        ArgumentException.ThrowIfNullOrEmpty(
            cep,
            nameof(cep));

        if (numero <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(numero));

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
        ArgumentException.ThrowIfNullOrEmpty(
            logradouro,
            nameof(logradouro));

        Logradouro = logradouro;
    }

    public void UpdateComplemento(string? complemento)
    {
        Complemento = complemento;
    }

    public void UpdateCep(string cep)
    {
        ArgumentException.ThrowIfNullOrEmpty(
            cep,
            nameof(cep));

        Cep = cep;
    }

    public void UpdateNumero(int numero)
    {
        if (numero <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(numero));

        Numero = numero;
    }
}