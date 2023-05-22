namespace ByteBank.Domain.SeedWork;

public interface IUnitOfWork
{
    Task CommitAsync();
}