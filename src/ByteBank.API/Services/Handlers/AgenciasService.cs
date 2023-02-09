// <copyright file="AgenciasService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using AutoMapper;

using ByteBank.API.Models;
using ByteBank.API.Repository;
using ByteBank.API.Request;
using ByteBank.API.ViewModels;

using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Services.Handlers
{
    public class AgenciasService : IAgenciasService
    {
        private readonly IRepository<Agencia> repository;
        private readonly IMapper _mapper;

        public AgenciasService(IRepository<Agencia> repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AgenciaViewModel>?> BuscaAgenciasAsync()
        {
            var agencia = await this.repository.BuscaTodosAsync();
            return _mapper.Map<List<AgenciaViewModel>>(agencia);
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

            return _mapper.Map<AgenciaViewModel>(agencia);
        }

        public async Task<bool> AlteraAgenciaAsync(AgenciaRequest agenciaRequest)
        {
            var agencia = _mapper.Map<Agencia>(agenciaRequest);
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
            var agencia = _mapper.Map<Agencia>(agenciaRequest);

            await this.repository.CriarAsync(agencia);
            return _mapper.Map<AgenciaViewModel>(agencia);
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
    }
}