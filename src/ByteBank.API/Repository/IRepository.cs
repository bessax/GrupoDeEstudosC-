namespace ByteBank.API.Repository
{
    public interface IRepository<T>
    {
        Task AlteraAsync(T obj);

        Task<T> BuscaPorIdAsync(int id);

        Task<List<T>> BuscaTodosAsync();

        Task CriarAsync(T obj);

        Task DeletaAsync(T obj);
    }
}