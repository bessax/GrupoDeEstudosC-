namespace ByteBank.Infrastructure.Data.ByteBank.Repositories;

public class ContaRepository : GenericRepository<Conta>, IContaRepository
{
    public ContaRepository(ByteBankContext context, IUnitOfWork unitOfWork)
        : base(context, unitOfWork)
    {
    }
}