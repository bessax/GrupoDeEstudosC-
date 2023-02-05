using bytebank_API.Models;

namespace bytebank_API.Services
{
    public interface IAgenciasService
    {
        Task<bool> AlteraAgenciaAsync(Agencia agencia);
        Task<Agencia?> BuscaAgenciaPorIdAsync(int id);
        Task<List<Agencia>?> BuscaAgenciasAsync();
        Task<Agencia> CriaAgenciaAsync(Agencia agencia);
        Task<bool> DeletaAgenciaAsync(int id);
    }
}