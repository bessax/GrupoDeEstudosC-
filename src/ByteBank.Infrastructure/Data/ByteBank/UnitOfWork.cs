namespace ByteBank.Infrastructure.Data.ByteBank;

public class UnitOfWork : IUnitOfWork
{
    private readonly ByteBankContext _context;

    public UnitOfWork(ByteBankContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}