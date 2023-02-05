using bytebank_API.Models;

namespace bytebank_API.Repository
{
    public interface IAgenciasRepository
    {
        Task AlteraAgenciaAsync(Agencia agencia);
        Task<Agencia> BuscaAgenciaPorIdAsync(int id);
        Task<List<Agencia>> BuscaAgenciasAsync();
        Task CriarAgenciaAsync(Agencia agencia);
        Task DeletaAgenciaAsync(Agencia agencia);
    }
}