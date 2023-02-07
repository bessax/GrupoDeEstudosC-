// <copyright file="ContaCorrenteService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using AutoMapper;

using ByteBank.API.Dtos;
using ByteBank.API.Interface;
using ByteBank.API.Models;

namespace ByteBank.API.Services.Handlers
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IMapper mapper;
        private readonly IContaCorrenteRepository repository;

        public ContaCorrenteService(IMapper mapper, IContaCorrenteRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<ContaCorrenteDto?> BuscaContaCorrentePorIdAsync(int id)
        {
            var contaCorrente = await this.repository.BuscaPorIdAsync(id);
            return this.mapper.Map<ContaCorrenteDto>(contaCorrente);
        }

        public async Task<IEnumerable<ContaCorrenteDto>> BuscaContasCorrentesAsync()
        {
            var contasCorrentes = await this.repository.BuscaTodosAsync();
            return this.mapper.Map<IEnumerable<ContaCorrenteDto>>(contasCorrentes);
        }

        public async Task<IEnumerable<ContaCorrenteDto>> BuscaContasCorrentesPaginadoAsync(int pagina, int tamanhoPagina)
        {
            var contasCorrentes = await this.repository.BuscaTodosPaginadoAsync(pagina, tamanhoPagina);
            return this.mapper.Map<IEnumerable<ContaCorrenteDto>>(contasCorrentes);
        }

        public async Task<IEnumerable<ContaCorrenteDto>> BuscaContasCorrentesPorCpfTitularAsync(string cpf)
        {
            var contasCorrentes = await this.repository.BuscaPorCpfTitularAsync(cpf);
            return this.mapper.Map<IEnumerable<ContaCorrenteDto>>(contasCorrentes);
        }

        public async Task<IEnumerable<ContaCorrenteDto>> BuscaContasCorrentesPorNomeTitularAsync(string nome)
        {
            var contasCorrentes = await this.repository.BuscaPorNomeTitularAsync(nome);
            return this.mapper.Map<IEnumerable<ContaCorrenteDto>>(contasCorrentes);
        }
    }
}