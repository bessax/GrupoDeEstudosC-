namespace ByteBank.Domain.AggregateModels.ContaAggregates;

public abstract class Conta : Entity, IAggregateRoot
{
    public decimal Saldo { get; protected set; }
    public int AgenciaId { get; private set; }
    public int ClienteId { get; private set; }
    public string Numero => $"{Id:D6}";

    public abstract void Depositar(decimal valor);
    public abstract void Sacar(decimal valor);
    public void Transferir(Conta destino, decimal valor)
    {
        Sacar(valor);
        destino.Depositar(valor);
    }
}