namespace ByteBank.Infrastructure.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : Entity, IAggregateRoot
{
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(ByteBankContext context, IUnitOfWork unitOfWork)
    {
        _dbSet = context.Set<TEntity>();
        UnitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync();
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetByPageAsync(int pageNumber, int pageSize)
    {
        return await _dbSet
            .OrderBy(e => e.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}