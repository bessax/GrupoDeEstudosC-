namespace ByteBank.Infrastructure.Data.Repositories;

public class AgenciaRepository : GenericRepository<Agencia>, IAgenciaRepository
{
    public AgenciaRepository(ByteBankContext context, IUnitOfWork unitOfWork)
        : base(context, unitOfWork)
    {
    }
}