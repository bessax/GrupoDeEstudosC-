using ByteBank.API.ViewModels;

namespace ByteBank.API.Services.Interfaces
{
    public interface IContaCorrenteService
    {
        Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesAsync();

        Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesPaginadoAsync(int pagina, int tamanhoPagina);

        Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesPorCpfTitularAsync(string cpf);

        Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesPorNomeTitularAsync(string nome);

        Task<ContaCorrenteViewModel?> BuscaContaCorrentePorIdAsync(int id);
    }
}