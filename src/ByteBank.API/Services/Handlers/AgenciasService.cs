// <copyright file="AgenciasService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Models;
using ByteBank.API.Repository;

using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Services.Handlers
{
    public class AgenciasService : IAgenciasService
    {
        private readonly IRepository<Agencia> repository;

        public AgenciasService(IRepository<Agencia> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Agencia>?> BuscaAgenciasAsync()
        {
            return await this.repository.BuscaTodosAsync();
        }

        public async Task<Agencia?> BuscaAgenciaPorIdAsync(int id)
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

            return agencia;
        }

        public async Task<bool> AlteraAgenciaAsync(Agencia agencia)
        {
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

        public async Task<Agencia> CriaAgenciaAsync(Agencia agencia)
        {
            await this.repository.CriarAsync(agencia);
            return agencia;
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