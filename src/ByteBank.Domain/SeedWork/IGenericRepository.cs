namespace ByteBank.Domain.SeedWork;

public interface IGenericRepository<TEntity> : IRepository<TEntity>
    where TEntity : Entity, IAggregateRoot
{
    void Add(TEntity entity);
    Task<int> Count();
    void Delete(TEntity entity);
    Task<TEntity?> GetById(int id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetByPage(int pageNumber, int pageSize);
}