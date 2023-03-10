namespace ByteBank.API.Repository.Interface
{
    public interface IRepository<T>
    {
        Task AlteraAsync(T obj);

        Task<T> BuscaPorIdAsync(int id);

        Task<List<T>> BuscaTodosAsync();

        Task CriarAsync(T obj);

        Task DeletaAsync(T obj);

        Task<IEnumerable<T>> BuscaTodosPaginadoAsync(int page, int pageSize);
    }
}