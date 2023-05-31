namespace ByteBank.Domain.SeedWork;

public interface IRepository<TEntity>
    where TEntity : Entity, IAggregateRoot
{
    public IUnitOfWork UnitOfWork { get; }
}