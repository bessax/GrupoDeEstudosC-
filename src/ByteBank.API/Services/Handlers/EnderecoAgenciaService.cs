using AutoMapper;
using ByteBank.API.Models;
using ByteBank.API.Repository.Interface;
using ByteBank.API.Request;
using ByteBank.API.Services.Interfaces;
using ByteBank.API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Services.Handlers
{
    public class EnderecoAgenciasService : IEnderecoAgenciasService
    {
        private readonly IEnderecoAgenciaRepository repository;
        private readonly IMapper _mapper;

        public EnderecoAgenciasService(IEnderecoAgenciaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EnderecoAgenciaViewModel>?> BuscaEnderecoAgenciasAsync()
        {
            var agencia = await this.repository.BuscaTodosAsync();
            return _mapper.Map<List<EnderecoAgenciaViewModel>>(agencia);
        }

        public async Task<EnderecoAgenciaViewModel?> BuscaEnderecoAgenciaPorIdAsync(int id)
        {
            if (await this.repository.BuscaTodosAsync() == null)
            {
                return null;
            }

            var endereco = await this.repository.BuscaPorIdAsync(id);

            if (endereco == null)
            {
                return null;
            }

            return _mapper.Map<EnderecoAgenciaViewModel>(endereco);
        }

        public async Task<bool> AlteraEnderecoAgenciaAsync(EnderecoAgenciaRequest objRequest)
        {

            var objeto = _mapper.Map<EnderecoAgencia>(objRequest);
            try
            {
                await this.repository.AlteraAsync(objeto.Id, objeto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this.EnderecoAgenciaExists(objeto.Id))
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

        public async Task<EnderecoAgenciaViewModel> CriaEnderecoAgenciaAsync(EnderecoAgenciaRequest objRequest)
        {
            var objeto = _mapper.Map<EnderecoAgencia>(objRequest);

            await this.repository.CriarAsync(objeto);
            return _mapper.Map<EnderecoAgenciaViewModel>(objeto);
        }

        public async Task<bool> DeletaEnderecoAgenciaAsync(int id)
        {
            if (await this.repository.BuscaTodosAsync() == null)
            {
                return false;
            }

            var endereco = await this.repository.BuscaPorIdAsync(id);

            if (endereco == null)
            {
                return false;
            }

            await this.repository.DeletaAsync(endereco.Id);
            return true;
        }

        private async Task<bool> EnderecoAgenciaExists(int id)
        {
            var enderecos = await this.repository.BuscaTodosAsync();
            return (enderecos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IEnumerable<EnderecoAgenciaViewModel>> EnderecoAgenciaPaginadoAsync(int pagina, int tamanhoPagina)
        {
            var enderecos = await this.repository.BuscaTodosPaginadoAsync(pagina, tamanhoPagina);
            return _mapper.Map<IEnumerable<EnderecoAgenciaViewModel>>(enderecos);
        }


    }
}