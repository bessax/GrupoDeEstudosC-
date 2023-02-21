using AutoMapper;

using ByteBank.API.Models;
using ByteBank.API.Repository.Interface;
using ByteBank.API.Request;
using ByteBank.API.Services.Interfaces;
using ByteBank.API.ViewModels;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Services.Handlers
{
    public class AgenciasService : IAgenciasService
    {
        private readonly IRepository<Agencia> repository;
        private readonly IMapper mapper;
        private readonly IValidator<AgenciaRequest> validator;

        public AgenciasService(IRepository<Agencia> repository, IMapper _mapper, IValidator<AgenciaRequest> validator)
        {
            this.repository = repository;
            this.mapper = _mapper;
            this.validator = validator;
        }

        public async Task<List<AgenciaViewModel>?> BuscaAgenciasAsync()
        {
            var agencia = await this.repository.BuscaTodosAsync();
            return this.mapper.Map<List<AgenciaViewModel>>(agencia);
        }

        public async Task<AgenciaViewModel?> BuscaAgenciaPorIdAsync(int id)
        {
            if (await this.repository.BuscaTodosAsync() == null)
            {
                return null;
            }

            var agencia = await this.repository.BuscaPorIdAsync(id);

            if (agencia == null)
            {
                return null;
            }

            return this.mapper.Map<AgenciaViewModel>(agencia);
        }

        public async Task<bool> AlteraAgenciaAsync(AgenciaRequest agenciaRequest)
        {
            await ValidaRequest(agenciaRequest);

            var agencia = this.mapper.Map<Agencia>(agenciaRequest);
            try
            {
                await this.repository.AlteraAsync(agencia);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this.AgenciaExists(agencia.Id))
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

        public async Task<AgenciaViewModel> CriaAgenciaAsync(AgenciaRequest agenciaRequest)
        {
            await ValidaRequest(agenciaRequest);

            var agencia = this.mapper.Map<Agencia>(agenciaRequest);

            await this.repository.CriarAsync(agencia);
            return this.mapper.Map<AgenciaViewModel>(agencia);
        }

        public async Task<bool> DeletaAgenciaAsync(int id)
        {
            if (await this.repository.BuscaTodosAsync() == null)
            {
                return false;
            }

            var agencia = await this.repository.BuscaPorIdAsync(id);

            if (agencia == null)
            {
                return false;
            }

            await this.repository.DeletaAsync(agencia);
            return true;
        }

        private async Task<bool> AgenciaExists(int id)
        {
            var agencias = await this.repository.BuscaTodosAsync();
            return (agencias?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task ValidaRequest(AgenciaRequest agenciaRequest)
        {
            await this.validator.ValidateAndThrowAsync(agenciaRequest);

        }

        public async Task<IEnumerable<AgenciaViewModel>> AgenciaPaginadoAsync(int pagina, int tamanhoPagina)
        {
            var agencias = await this.repository.BuscaTodosPaginadoAsync(pagina, tamanhoPagina);
            return mapper.Map<IEnumerable<AgenciaViewModel>>(agencias);
        }
    }
}