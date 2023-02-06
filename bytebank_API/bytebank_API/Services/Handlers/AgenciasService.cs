using bytebank_API.Models;
using bytebank_API.Repository;
using Microsoft.EntityFrameworkCore;

namespace bytebank_API.Services.Handlers
{
    public class AgenciasService : IAgenciasService
    {
        private readonly IRepository<Agencia> _repository;

        public AgenciasService(IRepository<Agencia> repository)
        {
            _repository = repository;
        }

        public async Task<List<Agencia>?> BuscaAgenciasAsync()
        {
            return await _repository.BuscaTodosAsync();
        }

        public async Task<Agencia?> BuscaAgenciaPorIdAsync(int id)
        {
            if (await _repository.BuscaTodosAsync() == null)
            {
                return null;
            }
            var agencia = await _repository.BuscaPorIdAsync(id);

            if (agencia == null)
            {
                return null;
            }

            return agencia;
        }

        public async Task<bool> AlteraAgenciaAsync(Agencia agencia)
        {
            try
            {
                await _repository.AlteraAsync(agencia);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AgenciaExists(agencia.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public async Task<Agencia> CriaAgenciaAsync(Agencia agencia)
        {
            await _repository.CriarAsync(agencia);
            return agencia;
        }

        public async Task<bool> DeletaAgenciaAsync(int id)
        {
            if (await _repository.BuscaTodosAsync() == null)
            {
                return false;
            }
            var agencia = await _repository.BuscaPorIdAsync(id);

            if (agencia == null)
            {
                return false;
            }

            await _repository.DeletaAsync(agencia);
            return true;
        }

        private async Task<bool> AgenciaExists(int id)
        {
            var agencias = await _repository.BuscaTodosAsync();
            return (agencias?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}