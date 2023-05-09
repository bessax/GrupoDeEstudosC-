namespace ByteBank.Domain.SeedWork;

public interface IGenericRepository<TEntity> : IRepository<TEntity>
    where TEntity : Entity, IAggregateRoot
{
    void Add(TEntity entity);
    Task<int> CountAsync();
    void Delete(TEntity entity);
    Task<TEntity?> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetByPageAsync(int pageNumber, int pageSize);
}