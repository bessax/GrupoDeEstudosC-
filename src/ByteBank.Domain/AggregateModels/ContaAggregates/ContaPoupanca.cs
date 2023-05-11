namespace ByteBank.Domain.AggregateModels.ContaAggregates;

public class ContaPoupanca : Conta
{
    public override void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new DomainException(
                "Não é possível depositar um valor igual o menor a zero");
        }

        Saldo += valor;
    }

    public override void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new DomainException(
                "Não é possível sacar um valor igual o menor a zero");
        }

        if (valor < Saldo)
        {
            throw new DomainException(
                "Não é possível sacar um valor menor ao saldo");
        }

        Saldo -= valor;
    }
}